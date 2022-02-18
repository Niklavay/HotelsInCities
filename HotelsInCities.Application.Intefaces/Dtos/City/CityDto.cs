using System.ComponentModel.DataAnnotations;

namespace HotelsInCities.Application.Intefaces.Dtos.City
{
    public class CityDto
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int Population { get; set; }
    }
}
