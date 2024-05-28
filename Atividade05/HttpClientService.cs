namespace Atividade05
{
    public class HttpClientService
    {
        private readonly IHttpClient _client;

        public HttpClientService(IHttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetDataFromApiAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
