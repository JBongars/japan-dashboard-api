using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using japan_dashboard_api.Models;
using japan_dashboard_api.Store;
using Microsoft.EntityFrameworkCore;

namespace japan_dashboard_api.Services
{
  public class PrefecturePopulationRepository : IPrefecturePopulationRepository
  {
    private readonly DataContext _context;

    public PrefecturePopulationRepository(DataContext context)
    {
      this._context = context;
    }

    public async Task<List<PrefecturePopulation>> GetPopulationForPrefecture(string prefecture)
    {
      var data = await _context.PrefecturePopulations.Where(elem => elem.prefectureIso == prefecture).ToListAsync();
      return data;
    }

  }
}
