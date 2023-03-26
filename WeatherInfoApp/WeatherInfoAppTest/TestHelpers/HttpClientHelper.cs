using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using WeatherInfoApp.Dto;

namespace WeatherInfoAppTest.TestHelpers
{
    public class HttpClientHelper
    {
        public static Mock<HttpMessageHandler> GetHttpMessageHandler()
        {
            var locations = MockData.GetLocations();
            var locationInfos = MockData.GetLocationInfos();

            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            foreach (Location location in locations)
            {
                var response = locationInfos.FirstOrDefault(x => x.Name.Equals(location.Name));

                var mockResponse = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response)),
                    StatusCode = HttpStatusCode.OK
                };

                mockResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                mockHandler.Protected()
                           .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(req => req.RequestUri == new Uri(location.Url)), ItExpr.IsAny<CancellationToken>())
                           .ReturnsAsync(mockResponse)
                           .Verifiable();
            }

            return mockHandler;
        }
    }
}
