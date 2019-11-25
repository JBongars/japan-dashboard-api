using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using japan_dashboard_api.Models;
using japan_dashboard_api.Store;

namespace japan_dashboard_api.Services
{
  public class PrefectureRepository : IPrefectureRepository
  {
    private readonly DataContext _context;

    public PrefectureRepository(DataContext context)
    {
      this._context = context;
    }

    public async Task<IEnumerable<Prefecture>> GetPrefectures()
    {
      var prefectures = await _context.Prefectures.ToListAsync();
      return prefectures;
    }
  }
}
