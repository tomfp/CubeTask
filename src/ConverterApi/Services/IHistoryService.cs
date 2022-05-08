using SharedData;
namespace ConverterApi.Services
{
    public interface IHistoryService
    {
        Task LogUsage(ConversionRequest? request);
    }
}
