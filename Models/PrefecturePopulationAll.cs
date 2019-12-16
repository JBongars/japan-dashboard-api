using System;

namespace japan_dashboard_api.Models
{
    public class PrefecturePopulationAll
    {
        public string gender { get; set; }
        public string age { get; set; }
        public string population { get; set; }

        public PrefecturePopulationAll(string gender, string age, string population)
        {
            this.gender = gender;
            this.age = age;
            this.population = population;
        }

        public PrefecturePopulationAll addToPopulation(long value){
            Console.WriteLine("current value");
            Console.WriteLine(this.population);
            long newValue = long.Parse(this.population) + value;
            return new PrefecturePopulationAll(this.gender, this.age, newValue.ToString());
        }
    }
}
