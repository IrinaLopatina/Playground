using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using WeatherInfoApp.Dto;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                               ILogger log)
        {
            log.LogInformation($"WeatherInfoFunction executed at: {DateTime.Now}");

            foreach (Location location in locations)
            {
                log.LogInformation(location.Name);

                var response = await httpClient.GetAsync(location.Url);

                // deserialize http content into an intermediary string
                var stringContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<LocationWeatherInfo>(stringContent);
            }
        }
    }
}
