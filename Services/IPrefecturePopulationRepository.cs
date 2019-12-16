using System.Collections.Generic;
using System.Threading.Tasks;
using japan_dashboard_api.Models;

namespace japan_dashboard_api.Services
{
  public interface IPrefecturePopulationRepository
  {
    Task<List<PrefecturePopulation>> GetPopulationForPrefecture(string prefectureIsoCode);
    Task<List<PrefecturePopulationAll>> GetPopulationForAll();
  }
}
