using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using WeatherInfoApp;
using WeatherInfoApp.Dto;

namespace WeatherInfoAppTest
{
    public class WeatherInfoFunctionTests
    {
        readonly WeatherInfoFunction sut = new();

        [Fact]
        public void DummyTest()
        {
            var timerInfo = default(TimerInfo); //null
            var log = Mock.Of<ILogger>();
            var locations = GetLocations();

            sut.Run(timerInfo, locations, log);
        }


        private static IEnumerable<Location> GetLocations()
        {
            var location1 = new Location {
                Name = "Oslo",
                Coordinate = new GeoCoordinate { Latitude = "59° 54' 45.83\" N", Longitude = "10° 44' 45.92\" E" },
                Url = "https://www.osloweather.no"
            };
            
            var location2 = new Location {
                Name = "Bergen",
                Coordinate = new GeoCoordinate { Latitude = "60° 23' 34.76\" N" , Longitude = "5° 19' 26.94\" E"},
                Url = "https://www.bergenweather.no"
            };

            return new Location[] { location1, location2};
        }
    }
}