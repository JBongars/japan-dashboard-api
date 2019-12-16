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

    private PrefecturePopulationRepository prefecturePopulationRepository;

    public PrefectureRepository(DataContext context)
    {
      this._context = context;
      this.prefecturePopulationRepository = new PrefecturePopulationRepository(context);
    }

    public async Task<List<Prefecture>> GetPrefectures()
    {
      var prefectures = await _context.Prefectures.ToListAsync();
      return prefectures;
    }

    public async Task<long> GetPrefecturePopulation(Prefecture prefecture)
    {
      List<PrefecturePopulation> populations = 
        await this.prefecturePopulationRepository.GetPopulationForPrefecture(prefecture.iso);

      long totalPoluation = 0;

      populations.ForEach(elem => {
        totalPoluation = totalPoluation + long.Parse(elem.population);
      });

      return totalPoluation;
    }

    public async Task<PrefectureResult> GetPrefectureResult(Prefecture prefecture){
      long totalPoluation = await GetPrefecturePopulation(prefecture);

      return new PrefectureResult(prefecture, totalPoluation);
    }

    public async Task<List<PrefectureResult>> GetPrefecturesWithPopulation()
    {
      var prefectures = await this.GetPrefectures();

      List<Task<PrefectureResult>> resultTaskList = prefectures.ConvertAll<Task<PrefectureResult>>(
        (prefecture) => GetPrefectureResult(prefecture)
      );

      Task.WaitAll(resultTaskList.ToArray());

      List<PrefectureResult> result = resultTaskList.ConvertAll<PrefectureResult>(elem => elem.Result);

      resultTaskList.ForEach(elem => {
        elem.Dispose();
      });

      return result;
    }
  }
}
