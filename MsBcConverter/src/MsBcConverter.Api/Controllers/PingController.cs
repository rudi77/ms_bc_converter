using Microsoft.AspNetCore.Mvc;

namespace MsBcConverter.Api.Controllers
{
    [ApiController]
    [Route("v1/ping")]
    public class PingController : ControllerBase
    {
        private readonly ILogger _logger;

        public PingController(ILoggerProvider logProvider)
        {
            _logger = logProvider.CreateLogger(nameof(PingController));
        }

        [HttpGet(Name = "GetPing")]
        public string Get()
        {
            return "pong";
        }
    }
}
