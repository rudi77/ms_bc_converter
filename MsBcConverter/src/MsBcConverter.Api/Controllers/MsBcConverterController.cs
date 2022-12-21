using Microsoft.AspNetCore.Mvc;

namespace MsBcConverter.Api.Controllers
{
    [ApiController]
    public class MsBcConverterResultController : ControllerBase
    {
        private readonly ILogger _logger;

        public MsBcConverterResultController(ILoggerProvider logProvider)
        {
            _logger = logProvider.CreateLogger(nameof(MsBcConverterResultController));
        }

        /// <summary>
        /// Takes as input a list of 'export table ids' and returns a list of download links
        /// to the generated excel files
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/conversion_result")]
        public string Get([FromQuery] string[] ids)
        {
            _logger.LogInformation($"Ids: {ids.Aggregate((a, b) => a + "," + b)}");
            return "Result";
        }
    }
}
