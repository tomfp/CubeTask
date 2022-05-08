using System.Text;

using Newtonsoft.Json;

using SharedData;

namespace ConvertClient.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TemperatureService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ServiceResponse<ConversionResult>> ConvertTemperature(string? valueToConvert, EnumTemperatureUnit fromUnits)
        {
            var httpClient = _httpClientFactory.CreateClient(ConfigValues.ConversionApi);
            var conversionRequest = new ConversionRequest
            {
                Value = valueToConvert,
                FromUnits = fromUnits,
                ClientId = ConfigValues.ClientId
            };
            var json = new StringContent(JsonConvert.SerializeObject(conversionRequest), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("TemperatureConversion", json);
            var serviceResponse = await SetResponse<ConversionResult>(response);
            if (response.IsSuccessStatusCode)
            {
                var returnObject = await response.Content.ReadAsStringAsync();
                serviceResponse.Data = JsonConvert.DeserializeObject<ConversionResult>(returnObject);
            }
            return serviceResponse;
        }

        private async Task<ServiceResponse<T>> SetResponse<T>(HttpResponseMessage response)
        {
            var serviceResponse = new ServiceResponse<T>
            {
                StatusCode = response.StatusCode,
            };
            if (!response.IsSuccessStatusCode)
            {
                serviceResponse.ErrorMessage = await response.Content.ReadAsStringAsync();
            }
            return serviceResponse;
        }
    }
}
