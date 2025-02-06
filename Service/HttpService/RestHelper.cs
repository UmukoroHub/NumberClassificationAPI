
using System.Net.Http;

namespace NumberClassificationAPI.Service.HttpService
{
    public class RestHelper : IRestHelper
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RestHelper> _logger;
        public RestHelper(HttpClient httpClient, ILogger<RestHelper> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<string> GetFunFact(int number)
        {
            string url = $"http://numbersapi.com/{number}/math";
            _logger.LogInformation($"Proceeding to get number fact from external API. Payload = {url} ");
            try
            {
                return await _httpClient.GetStringAsync(url);
            }
            catch
            {
                return "Fun fact not available";
            }
        }
    }
}
