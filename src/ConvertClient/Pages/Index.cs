using ConvertClient.Model;
using ConvertClient.Services;
using Microsoft.AspNetCore.Components;

namespace ConvertClient.Pages
{
    public partial class Index
    {
        [Inject]
        ITemperatureService TemperatureService { get; set; }

        TemperatureModel temperatureModel = new TemperatureModel();

        public async void GetResults()
        {

            temperatureModel.ConversionResult = null;
            await PerformConversion();
        }

        private async Task PerformConversion()
        {
            var result =
                await TemperatureService.ConvertTemperature(temperatureModel.Temperature, temperatureModel.FromUnits);
            if (result.HasErrors)
            {
                temperatureModel.ConversionResult = $"Conversion failed: {result.ErrorMessage}";
            }
            else
            {
                temperatureModel.ConversionResult =
                    $@"{result.Data.CelsiusValue} Celsius | {result.Data.FahrenheitValue} Fahrenheit | {result.Data.KelvinValue} Kelvin";
            }
            StateHasChanged();
        }
    }
}
