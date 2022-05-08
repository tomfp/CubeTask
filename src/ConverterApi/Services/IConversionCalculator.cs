using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedData;

namespace ConverterApi.Services
{
    public interface IConversionCalculator
    {
        Task<ConversionResult> Convert(ConversionRequest request);
    }
}
