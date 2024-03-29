using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using WeatherInfoApp;
using WeatherInfoApp.Dto;
using Moq.Protected;
using WeatherInfoAppTest.TestHelpers;
using Azure.Messaging.ServiceBus;

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
        public async void Function_ShouldSend_GetWithSpecifiedUrl_OnceForEachLocation()
        {
            var timerInfo = default(TimerInfo); //null
            var locations = MockData.GetLocations();
            var serviceBusMessageCollector = new Mock<IAsyncCollector<ServiceBusMessage>>();
            var log = Mock.Of<ILogger>();

            //Act
            await sut.Run(timerInfo, locations, serviceBusMessageCollector.Object, log);

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


        [Fact]
        public async Task Function_ShouldAdd_ServiceBussMessage_ForEachLocation()
        {
            //Arrange
            var timerInfo = default(TimerInfo); //null
            var locations = MockData.GetLocations();
            var serviceBusMessageCollector = new Mock<IAsyncCollector<ServiceBusMessage>>();
            var log = Mock.Of<ILogger>();

            serviceBusMessageCollector
                .Setup(x => x.AddAsync(It.IsAny<ServiceBusMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            //Act
            await sut.Run(timerInfo, locations, serviceBusMessageCollector.Object, log);

            //Assert
            serviceBusMessageCollector.Verify(x => x.AddAsync(It.IsAny<ServiceBusMessage>(), It.IsAny<CancellationToken>()), Times.Exactly(locations.Count));

            //Todo: test messages
        }
    }
}