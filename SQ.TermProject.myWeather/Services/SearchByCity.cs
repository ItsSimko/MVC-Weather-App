using System.ComponentModel.DataAnnotations;

namespace SQ.TermProject.myWeather.Models
{
    public class SearchByCity
    {
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "City name is empty ")]
        [StringLength(30, MinimumLength= 2, ErrorMessage = "Invalid Input")]
        public string CityName { get; set; }


    }
}
