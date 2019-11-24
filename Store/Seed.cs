using System.Collections.Generic;
using System.Linq;
using japan_dashboard_api.Models;
using Newtonsoft.Json;

namespace japan_dashboard_api.Store
{
  public class Seed
  {
    public static void SeedAll(DataContext context)
    {
      if (context.Prefectures.Any() || context.PrefecturePopulations.Any())
      {
        return;
      }
      List<Prefecture> prefectureData = getData<Prefecture>("Prefecture");
      List<PrefecturePopulation> prefecturePopulationData = getData<PrefecturePopulation>("PrefecturePopulation");

      foreach (var prefecture in prefectureData)
      {
        context.Prefectures.Add(prefecture);
      }

      foreach (var prefecturePopulation in prefecturePopulationData)
      {
        context.PrefecturePopulations.Add(prefecturePopulation);
      }

      context.SaveChanges();
    }

    private static List<t> getData<t>(string contextPropertyName)
    {
      var rawData = System.IO.File.ReadAllText($"Seeds/{contextPropertyName}.json");
      var data = JsonConvert.DeserializeObject<List<t>>(rawData);

      return data;
    }
  }
}
