using SharedData;

namespace ConvertClient.Services
{
    public interface ITemperatureService
    {
        Task<ServiceResponse<ConversionResult>> ConvertTemperature(string? valueToConvert, EnumTemperatureUnit fromUnits);
    }
}
