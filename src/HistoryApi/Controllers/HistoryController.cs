using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedData;
using Serilog;
using ILogger = Serilog.ILogger;

namespace HistoryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly ILogger _logger;

        public HistoryController(ILogger logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult LogUsage([FromBody] ConversionRequest? request)
        {
            string logMessage;
            if (request == null)
            {
                logMessage = "Null Request";
            }
            else
            {
                logMessage = $"Value: {request.Value}, FromUnits: {request.FromUnits}, ClientId: {request.ClientId}";
            }
            _logger.Information(logMessage);
            return NoContent();
        }
    }
}
