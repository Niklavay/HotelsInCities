using HotelsInCities.Domain.Core.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelsInCities.Domain.Core.Entities
{
    public class City : IGenericEntity<int>
    {
        private readonly List<Hotel> hotels = new List<Hotel>();

        public int Id { get; private set; } 

        [Required(ErrorMessage = "Please name the city.")]
        public string Name { get; private set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int Population { get; private set; }

        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public double Longitude { get; private set; }

        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public double Latitude { get; private set; }

        public City()
        {
        }

        public City (string name, int population, double latitude, double longitude)
        {
            Name = name;
            Population = population;
            Latitude = latitude;
            Longitude = longitude;
        }

        public IEnumerable<Hotel> Hotels
        {
            get { return hotels; }
        }

        public void ChangeInfo(string name, int population, double latitude, double longitude)
        {
            RenameCity(name);
            ChangeLatitudeLongitude(latitude, longitude);
            ChangeAmountOfPopulation(population);
        }

        public void AddHotel(Hotel hotel)
        {
            if (hotels.Contains(hotel))
                return;

            hotels.Add(hotel);
        }

        public void Removehotel(Hotel hotel)
        {
            if(hotels.Contains(hotel))
                hotels.Remove(hotel);
            else
                return;
        }

        public void RenameCity(string newName)
        {
            if(newName != null)
                Name = newName; 
        }
        public void ChangeAmountOfPopulation(int newPopulation)
        {
            if(newPopulation >= 0)
                Population = newPopulation;
        }
        public void ChangeLatitudeLongitude(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude= longitude;
        }
    }
}