namespace SharedData
{
    public class ConversionResult
    {
        public EnumTemperatureUnit FromUnits { get; set; }
        public double? CelsiusValue { get; set; }
        public double? KelvinValue { get; set; }
        public double? FahrenheitValue { get; set; }
        public string? Message { get; set; }
    }
}
