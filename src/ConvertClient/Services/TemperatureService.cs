using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace ConvertClient.Services
{
    public class TemperatureService : ITemperatureService
    {
        public Task<ConversionResult> ConvertTemperature(string valueToConvert, EnumTemperatureUnit fromUnits)
        {
            throw new NotImplementedException();
        }
    }
}
