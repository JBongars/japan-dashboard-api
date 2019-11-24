namespace japan_dashboard_api.Models
{
  public class PrefecturePopulation
  {
    public PrefecturePopulation(string prefectureIso, string gender, string age, string population)
    {
      this.prefectureIso = prefectureIso;
      this.gender = gender;
      this.age = age;
      this.population = population;

    }
    private string prefectureIso { get; }
    private string gender { get; }
    private string age { get; }
    private string population { get; }
  }
}
