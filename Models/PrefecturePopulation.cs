namespace japan_dashboard_api.Models
{
  public class PrefecturePopulation
  {
    public int Id { get; set; }
    public string prefectureIso { get; set; }
    public string gender { get; set; }
    public string age { get; set; }
    public string population { get; set; }
  }
}
