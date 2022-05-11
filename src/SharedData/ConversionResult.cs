namespace SharedData
{
    public class ConversionResult
    {
        public EnumTemperatureUnit FromUnits { get; set; }
        public string? CelsiusValue { get; set; }
        public string? KelvinValue { get; set; }
        public string? FahrenheitValue { get; set; }
        public string? Message { get; set; }
    }
}
