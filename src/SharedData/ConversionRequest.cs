namespace SharedData;
public class ConversionRequest
{
    public string? Value { get; set; }
    public EnumTemperatureUnit FromUnits { get; set; }

    public string? ClientId { get; set; }
}
