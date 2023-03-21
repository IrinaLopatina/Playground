using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using WeatherInfoApp.Dto;

namespace WeatherInfoApp
{
    public class WeatherInfoFunction
    {
        [FunctionName("WeatherInfoFunction")]
        public void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer,
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
            }
        }
    }
}
