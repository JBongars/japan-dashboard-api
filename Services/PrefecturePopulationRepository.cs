using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System;
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

    public async Task<List<PrefecturePopulationAll>> GetPopulationForAll()
    {
      var data = await _context.PrefecturePopulations.ToListAsync();
      List<PrefecturePopulationAll> result = new List<PrefecturePopulationAll>();
      
      data.ForEach(row => {
        int index = result.FindIndex(elem => elem.gender == row.gender && elem.age == row.age);

        if(index > -1){
          result[index] = result[index].addToPopulation(long.Parse(row.population));
        } else {
          result.Add(new PrefecturePopulationAll(
            row.gender,
            row.age,
            row.population
          ));
        }
      });

      return result;
    }

    public async Task<List<PrefecturePopulation>> GetPopulationForPrefecture(string prefecture)
    {
      var data = await _context.PrefecturePopulations.Where(elem => elem.prefectureIso == prefecture).ToListAsync();
      return data;
    }

  }
}
