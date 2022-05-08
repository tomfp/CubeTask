using SharedData;

namespace ConverterApi.Services
{
    public interface IConversionCalculator
    {
        Task<ConversionResult> Convert(ConversionRequest request);
    }
}
