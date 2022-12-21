using Microsoft.AspNetCore.Mvc;

namespace MsBcConverter.Api.Controllers
{
    [ApiController]
    [Route("v1/converter_result")]
    public class MsBcConverterResultController : ControllerBase
    {
        private readonly ILogger _logger;

        public MsBcConverterResultController(ILoggerProvider logProvider)
        {
            _logger = logProvider.CreateLogger(nameof(MsBcConverterResultController));
        }

        [HttpPost(Name = "PostMsBcConverter")]
        public string Post()
        {
            return "Result";
        }
    }
}
