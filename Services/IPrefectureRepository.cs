using System.Collections.Generic;
using System.Threading.Tasks;
using japan_dashboard_api.Models;

namespace japan_dashboard_api.Services
{
  public interface IPrefectureRepository
  {
    Task<IEnumerable<Prefecture>> GetPrefectures();

  }
}
