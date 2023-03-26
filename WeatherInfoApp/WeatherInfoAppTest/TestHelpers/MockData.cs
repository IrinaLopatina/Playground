using WeatherInfoApp.Dto;

namespace WeatherInfoAppTest.TestHelpers
{
    public class MockData
    {
        public static List<Location> GetLocations()
        {
            var location1 = new Location
            {
                Name = "Oslo",
                Coordinate = new GeoCoordinate { Latitude = "59° 54' 45.83\" N", Longitude = "10° 44' 45.92\" E" },
                Url = "https://www.weather.no/oslo"
            };

            var location2 = new Location
            {
                Name = "Bergen",
                Coordinate = new GeoCoordinate { Latitude = "60° 23' 34.76\" N", Longitude = "5° 19' 26.94\" E" },
                Url = "https://www.weather.no/bergen"
            };

            return new List<Location> { location1, location2 };
        }

        public static List<LocationWeatherInfo> GetLocationInfos()
        {
            var locationInfo1 = new LocationWeatherInfo
            {
                Name = "Oslo",
                Coordinate = new GeoCoordinate { Latitude = "59° 54' 45.83\" N", Longitude = "10° 44' 45.92\" E" },
                Temperature = 12.7,
                WindStrength = 2.5,
                Humidity = 67,
                DateTime = new DateTime(2023, 3, 26, 17, 15, 0)
            };

            var locationInfo2 = new LocationWeatherInfo
            {
                Name = "Bergen",
                Coordinate = new GeoCoordinate { Latitude = "60° 23' 34.76\" N", Longitude = "5° 19' 26.94\" E" },
                Temperature = 10.1,
                WindStrength = 6.2,
                Humidity = 84,
                DateTime = new DateTime(2023, 3, 26, 17, 15, 0)
            };

            return new List<LocationWeatherInfo> { locationInfo1, locationInfo2 };
        }
    }
}
