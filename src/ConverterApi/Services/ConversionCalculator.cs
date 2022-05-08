using SharedData;

namespace ConverterApi.Services
{
    public class ConversionCalculator : IConversionCalculator
    {
        public const double zeroCasK = 273.15;
        public const double zeroCasF = 32.0;
        public ConversionResult Convert(ConversionRequest request)
        {
            ConversionResult result = new ConversionResult{ FromUnits = request.FromUnits };
            double celsiusValue = 0;
            double fahrenheitValue = 0;
            double kelvinValue = 0;
            if (string.IsNullOrWhiteSpace(request.Value))
            {
                result.Message = $"No value to convert";
                return result;
            }
            if (!double.TryParse(request.Value, out double inputValue))
            {
                result.Message = $"Value '{request.Value}' not a number";
                return result;
            }
            switch (request.FromUnits)
            {
                case EnumTemperatureUnit.Celsius:
                    celsiusValue = inputValue;
                    fahrenheitValue = inputValue * (9.0/5.0) + zeroCasF;
                    kelvinValue = inputValue + zeroCasK;
                    break;
                case EnumTemperatureUnit.Kelvin:
                    kelvinValue = inputValue;
                    celsiusValue = inputValue - zeroCasK;
                    fahrenheitValue = celsiusValue * (9.0/5.0) + zeroCasF;
                    break;
                case EnumTemperatureUnit.Fahrenheit:
                    fahrenheitValue = inputValue;
                    celsiusValue = (inputValue - zeroCasF) * (5.0/9.0);
                    kelvinValue = celsiusValue + zeroCasK;
                    break;
                default:
                    result.Message = $"Cannot convert from {request.FromUnits}";
                    break;
            }
            // Range limit
            if (kelvinValue < 0)
            {
                result.Message =
                    $"Value is below absolute zero. This is a mathematical result only and cannot describe a physical universe temperature.";
            }
            result.CelsiusValue = $"{celsiusValue}";
            result.KelvinValue = $"{kelvinValue}";
            result.FahrenheitValue = $"{fahrenheitValue}";
            return result;
        }
    }
}
