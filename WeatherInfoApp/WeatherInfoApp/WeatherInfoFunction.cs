using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace WeatherInfoApp
{
    public class WeatherInfoFunction
    {
        [FunctionName("WeatherInfoFunction")]
        public void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"WeatherInfoFunction executed at: {DateTime.Now}");
        }
    }
}
