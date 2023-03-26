using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using WeatherInfoApp;
using WeatherInfoApp.Dto;
using Moq.Protected;
using WeatherInfoAppTest.TestHelpers;

namespace WeatherInfoAppTest
{
    public class WeatherInfoFunctionTests
    {
        readonly WeatherInfoFunction sut;
        readonly Mock<HttpMessageHandler> handlerMock;

        public WeatherInfoFunctionTests()
        {
            //Arrange
            handlerMock = HttpClientHelper.GetHttpMessageHandler();

            var httpClient = new HttpClient(handlerMock.Object);
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);

            sut = new (mockHttpClientFactory.Object);
        }

        [Fact]
        public async void Verify_Get_WithSpecifiedUrl_IsCalledOnce_ForEachLocation()
        {
            var timerInfo = default(TimerInfo); //null
            var log = Mock.Of<ILogger>();
            var locations = MockData.GetLocations();

            //Act
            await sut.Run(timerInfo, locations, log);

            //Assert
            foreach (Location location in locations)
            {
                handlerMock.Protected()
                           .Verify("SendAsync", Times.Exactly(1),
                                   ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri == new Uri(location.Url)),
                                   ItExpr.IsAny<CancellationToken>()
                );
            }
        }
    }
}