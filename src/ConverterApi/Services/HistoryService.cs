using System.Text;

using Newtonsoft.Json;

using SharedData;
namespace ConverterApi.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HistoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task LogUsage(ConversionRequest? request)
        {
            var httpClient = _httpClientFactory.CreateClient(ConfigValues.HistoryApi);
            var json = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("LogUsage", json);
            
        }
    }
}
