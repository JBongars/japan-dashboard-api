using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using japan_dashboard_api.Models;
using japan_dashboard_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace japan_dashboard_api.Controllers
{

  [ApiController]
  [Route("prefecture")]
  public class PrefecturePopulationController : ControllerBase
  {
    private readonly ILogger<PrefecturePopulationController> _logger;
    private readonly IPrefectureRepository _prefectureRepository;
    private readonly IPrefecturePopulationRepository _prefecturePopulationRepository;

    public PrefecturePopulationController(ILogger<PrefecturePopulationController> logger, IPrefectureRepository prefectureRepository, IPrefecturePopulationRepository prefecturePopulationRepository)
    {
      _logger = logger;
      _prefectureRepository = prefectureRepository;
      _prefecturePopulationRepository = prefecturePopulationRepository;
    }

    [HttpGet("")]
    public ActionResult<IEnumerable<Prefecture>> getPrefectures()
    {
      var data = _prefectureRepository.GetPrefectures();
      return Ok(data);
    }

    [HttpGet("{isoCode}")]
    public ActionResult<IEnumerable<PrefecturePopulation>> getPopulationByPrefecture(string isoCode)
    {
      var data = _prefecturePopulationRepository.GetPopulationForPrefecture(isoCode);
      return Ok(data);
    }

    [HttpGet("test")]
    public ActionResult<string> test()
    {
      return Ok("hello");
    }

  }
}
