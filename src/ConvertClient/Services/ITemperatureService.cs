using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace ConvertClient.Services
{
    public interface ITemperatureService
    {
        Task<ConversionResult> ConvertTemperature(string valueToConvert, EnumTemperatureUnit fromUnits);
    }
}
