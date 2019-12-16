namespace japan_dashboard_api.Models
{
    public class PrefectureResult
    {
        public Prefecture prefectureDetails { get; set; }
        public long population { get; set; }

        public PrefectureResult (Prefecture prefecture, long population)
        {
            this.population = population;
            this.prefectureDetails = prefecture;
        }

    }
}
