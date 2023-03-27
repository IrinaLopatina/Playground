using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using WeatherInfoApp.Dto;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using Azure.Messaging.ServiceBus;

namespace WeatherInfoApp
{
    public class WeatherInfoFunction
    {
        private readonly string clientName = "WeatherInfoFunctionHttpClient";
        private readonly HttpClient httpClient;

        public WeatherInfoFunction(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(clientName);
        }

        [FunctionName("WeatherInfoFunction")]
        public async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo timerInfo,
                              [CosmosDB(
                                databaseName: "SampleDB",
                                containerName: "Locations",
                                Connection = "CosmosDBConnection",
                                SqlQuery = "SELECT * FROM c")]IEnumerable<Location> locations,
                              [ServiceBus("<queue_or_topic_name>", Connection = "AzureServiceBusConnection")] IAsyncCollector<ServiceBusMessage> collector,
                               ILogger log)
        {
            log.LogInformation($"WeatherInfoFunction executed at: {DateTime.Now}");

            // Define Polly policies
            var policy = Policy.Handle<Exception>()
                               .WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(500), (e, t, i, c) => log.LogError($"Error '{e.Message}' at retry #{i}"));
            var pollyContext = new Context();
          
            foreach (Location location in locations)
            {
                log.LogInformation(location.Name);

                var response = await policy.ExecuteAsync(async ctx =>
                {
                    var response = await httpClient.GetAsync(location.Url);
                    response.EnsureSuccessStatusCode();
                    return response;
                }, pollyContext);

                // Deserialize http content into an intermediary string
                var stringContent = await response.Content.ReadAsStringAsync();

                // Make/map to an object, containing Name and Coordinates to support filter on these properties. 
                var result = JsonConvert.DeserializeObject<LocationWeatherInfo>(stringContent);

                // IAsyncCollector allows sending multiple messages in a single function invocation
                await collector.AddAsync(new ServiceBusMessage(new BinaryData(result)));
            }
        }
    }
}
