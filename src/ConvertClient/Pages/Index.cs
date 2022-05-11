using ConvertClient.Model;
using ConvertClient.Services;
using Microsoft.AspNetCore.Components;

namespace ConvertClient.Pages
{
    public partial class Index
    {
        [Inject]
        ITemperatureService? TemperatureService { get; set; }

        readonly TemperatureModel _temperatureModel = new();

        public async void GetResults()
        {

            _temperatureModel.ConversionResult = null;
            await PerformConversion();
        }

        private async Task PerformConversion()
        {
            if (TemperatureService == null)
            {
                throw new ArgumentNullException(nameof(TemperatureService));
            }
            var result =
                await TemperatureService.ConvertTemperature(_temperatureModel.Temperature, _temperatureModel.FromUnits);
            if (result.HasErrors||result.Data == null )
            {
                _temperatureModel.ConversionResult = $"Conversion failed: {result.ErrorMessage}";
            }
            else
            {
                _temperatureModel.ConversionResult =
                    $@"{result.Data.CelsiusValue} Celsius | {result.Data.FahrenheitValue} Fahrenheit | {result.Data.KelvinValue} Kelvin ";
                if (result.Data.Message != null)
                {
                    _temperatureModel.ConversionResult += $"({result.Data.Message})";
                }
            }
            StateHasChanged();
        }
    }
}
