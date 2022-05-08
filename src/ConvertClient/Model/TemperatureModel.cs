using SharedData;

namespace ConvertClient.Model
{
    public class TemperatureModel
    {
        public string? Temperature { get; set; }

        public EnumTemperatureUnit FromUnits { get; set; } = EnumTemperatureUnit.Celsius;

        public string? ConversionResult { get; set; }
    }
}
