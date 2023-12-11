using System.ComponentModel.DataAnnotations;

namespace SQ.TermProject.myWeather.Models
{
    public class City
    {
        [Display (Name = "City Name")] 
        public string Name { get; set; }

        [Display (Name = "Temp. ")]
        public float Temperature {  get; set; } 
        
        public int MyProperty { get; set; }

        [Display (Name = "Humdity")]
        public int Humidity { get; set; }

        [Display (Name = "Pressure")]
        public int Pressure { get; set; }

        [Display (Name = "Wind Speed")]
        public float Wind { get; set; }

        [Display(Name = "Weather Condition:")]

        public string Weather { get; set; }


    }
}
