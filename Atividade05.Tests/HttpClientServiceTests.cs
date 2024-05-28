using NSubstitute;

namespace Atividade05.Tests
{
    public class HttpClientServiceTests
    {
        [Fact]
        public async Task GetDataFromApiAsync_UnitTest_ReturnsData()
        {
            var mockHttpClient = Substitute.For<IHttpClient>();

            var response = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("{\"key\":\"value\"}")
            };

            mockHttpClient.GetAsync(Arg.Any<string>()).Returns(Task.FromResult(response));
            var service = new HttpClientService(mockHttpClient);

            var data = await service.GetDataFromApiAsync("http://fakeapi.com/data");

            Assert.Equal("{\"key\":\"value\"}", data);
        }

        [Fact]
        public async Task GetDataFromApiAsync_IntegrationTest_ReturnsData()
        {
            // Arrange

            // Instancia o HttpClient real
            var httpClient = new HttpClient();

            // Encapsula o HttpClient real no HttpClientWrapper
            var HttpClientWrapper = new HttpClientWrapper(httpClient);

            // Passa o HttpClientWrapper para o HttpClientService (Injeção de Dependência)
            var httpClientService = new HttpClientService(HttpClientWrapper);

            string url = "https://jsonplaceholder.typicode.com/posts/1";

            // Act
            string data = await httpClientService.GetDataFromApiAsync(url);

            // Assert
            Assert.False(string.IsNullOrEmpty(data));
            Assert.Contains("userId", data);
        }
    }
}