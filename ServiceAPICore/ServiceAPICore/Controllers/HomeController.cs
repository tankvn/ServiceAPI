using Microsoft.AspNetCore.Mvc;

namespace ServiceAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public static readonly string VERSION_CODE = "V1.0.0";
        public static readonly string VERSION_DATE = "2024-11-21 10:09:00";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHomeInfo")]
        public HomeInfo Get()
        {
            return new HomeInfo
            {
                Version = VERSION_CODE,
                Date = VERSION_DATE,
                Summary = "Web API with ASP.NET Core"
            };
        }
    }
}
