using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace ConverterApi.Services
{
    public class ConversionCalculator : IConversionCalculator
    {
        public Task<ConversionResult> Convert(ConversionRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
