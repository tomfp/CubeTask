using ConverterApi.Services;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedData;

namespace ConverterApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class TemperatureConversionController : ControllerBase
    {
        private readonly ILogger<TemperatureConversionController> _logger;
        private readonly IConversionCalculator _conversionCalculator;
        private readonly IHistoryService _historyService;
        public TemperatureConversionController(
            ILogger<TemperatureConversionController> logger,
            IConversionCalculator conversionCalculator,
            IHistoryService historyService)
        {
            _logger = logger;
            _conversionCalculator = conversionCalculator;
            _historyService = historyService;
        }

        [HttpPost]
        public async  Task<IActionResult> ConvertTemperature([FromBody] ConversionRequest? request)
        {
            await LogUsage(request);
            try
            {
                //  some basic validation
                if (request == null)
                {
                    return BadRequest();
                }
                if (request.FromUnits == EnumTemperatureUnit.NotSpecified)
                {
                    return BadRequest();
                }
                var result =  _conversionCalculator.Convert(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"ConvertTemperature {request?.Value} From {request?.FromUnits}");
                return StatusCode(500);
            }
        }

        private async Task LogUsage(ConversionRequest? request)
        {
            try
            {
                await _historyService.LogUsage(request);
            }
            catch (Exception e)
            {
                _logger.LogWarning($"LogUsage Failed: {e.Message}");
            }
        }
    }
}
