using SharedData;

namespace ConverterApi.Services
{
    public interface IConversionCalculator
    {
        ConversionResult Convert(ConversionRequest request);
    }
}
