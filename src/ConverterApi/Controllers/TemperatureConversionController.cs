using ConverterApi.Services;

using Microsoft.AspNetCore.Mvc;

using SharedData;

namespace ConverterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureConversionController : ControllerBase
    {
        private readonly ILogger<TemperatureConversionController> _logger;
        private readonly IConversionCalculator _conversionCalculator;
        public TemperatureConversionController(
            ILogger<TemperatureConversionController> logger,
            IConversionCalculator conversionCalculator)
        {
            _logger = logger;
            _conversionCalculator = conversionCalculator;
        }

        [HttpPost]
        public async Task<IActionResult> ConvertTemperature([FromBody] ConversionRequest? request)
        {
            try
            {
                // TODO Log Requests
                //  some basic validation
                if (request == null)
                {
                    return BadRequest();
                }
                if (request.FromUnits == EnumTemperatureUnit.NotSpecified)
                {
                    return BadRequest();
                }
                var result = await _conversionCalculator.Convert(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"ConvertTemperature {request?.Value} From {request?.FromUnits}");
                return StatusCode(500);
            }
        }
    }
}
