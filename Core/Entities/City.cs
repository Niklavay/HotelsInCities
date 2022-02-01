using Core.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class City : IGenericEntity<int>
    {
        private readonly List<Hotel> hotels;

        public int Id { get; private set; } 
        [Required(ErrorMessage = "Please name the city.")]
        public string Name { get; private set; }
        [Required]
        public int Population { get; private set; }
        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public int GPSCoordinates { get; private set; }

        public City()
        {
            hotels = new List<Hotel>();
        }

        public City (string name, int population, int gpsCoordinates)
        {
            Name = name;
            Population = population;
            GPSCoordinates = gpsCoordinates;
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

        public void ChangeGPSCoordinates(int newGPSCoordinates)
        {
            GPSCoordinates = newGPSCoordinates;
        }
    }
}