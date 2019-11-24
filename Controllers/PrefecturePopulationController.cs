using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace japan_dashboard_api.Controllers
{

  [ApiController]
  [Route("prefecture")]
  public class PrefecturePopulationController : ControllerBase
  {
    private readonly ILogger<PrefecturePopulationController> _logger;

    public PrefecturePopulationController(ILogger<PrefecturePopulationController> logger)
    {
      _logger = logger;
    }

    [HttpGet("test")]
    public ActionResult<string> test()
    {
      _logger.LogInformation("hit");
      return "hello";
    }
  }
}
