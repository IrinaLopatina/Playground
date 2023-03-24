using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using WeatherInfoApp;
using WeatherInfoApp.Dto;
using Moq.Protected;

namespace WeatherInfoAppTest
{
    public class WeatherInfoFunctionTests
    {
        readonly WeatherInfoFunction sut;
        readonly Mock<HttpMessageHandler> handlerMock;

        public WeatherInfoFunctionTests()
        {
            handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
       
            var result = new HttpResponseMessage();

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(result)
                       .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(x => x.CreateClient("WeatherInfoFunctionHttpClient")).Returns(httpClient);

            sut = new (mockHttpClientFactory.Object);
        }

        [Fact]
        public async void Verify_Get_WithSpecifiedUrl_IsCalledOnce_ForEachLocation()
        {
            var timerInfo = default(TimerInfo); //null
            var log = Mock.Of<ILogger>();
            var locations = GetLocations();

            //Act
            await sut.Run(timerInfo, locations, log);

            //Assert
            for (int i = 0; i < locations.Count; i++)
            {
                handlerMock.Protected()
                           .Verify("SendAsync", Times.Exactly(1),
                                   ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == new Uri(locations[0].Url)),
                                   ItExpr.IsAny<CancellationToken>()
                );
            }
        }


        private static List<Location> GetLocations()
        {
            var location1 = new Location {
                Name = "Oslo",
                Coordinate = new GeoCoordinate { Latitude = "59° 54' 45.83\" N", Longitude = "10° 44' 45.92\" E" },
                Url = "https://www.weather.no/oslo"
            };
            
            var location2 = new Location {
                Name = "Bergen",
                Coordinate = new GeoCoordinate { Latitude = "60° 23' 34.76\" N" , Longitude = "5° 19' 26.94\" E"},
                Url = "https://www.weather.no/bergen"
            };

            return new List<Location> { location1, location2};
        }
    }
}