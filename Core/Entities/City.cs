using Core.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class City : IGenericEntity<int>
    {
        private readonly List<Hotel> hotels = new List<Hotel>();

        public int Id { get; private set; } 

        [Required(ErrorMessage = "Please name the city.")]
        public string? Name { get; private set; }

        [Required]
        public int Population { get; private set; }

        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public int Longitude { get; private set; }

        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public int Latitude { get; private set; }

        public City()
        {
        }

        public City (string name, int population, int latitude, int longitude)
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
            Name = newName; 
        }
        public void ChangeAmountOfPopulation(int newPopulation)
        {
            Population = newPopulation;
        }

        /*public void ChangeGPSCoordinates(int newLon)
        {
            GPSCoordinates = newGPSCoordinates;
        }*/
    }
}