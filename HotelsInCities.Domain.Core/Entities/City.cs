using HotelsInCities.Domain.Common.Enums;
using HotelsInCities.Domain.Core.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HotelsInCities.Domain.Core.Entities
{
    public class City : IGenericEntity<int>
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();

        public int Id { get; private set; } 
        [NotNull]
        [Required(ErrorMessage = "Please name the city.")]
        public string Name { get; private set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public int Population { get; private set; }

        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public double Longitude { get; private set; }

        [Required(ErrorMessage = "Every city has it's own coordinates.")]
        public double Latitude { get; private set; }

        private City()
        {
        }

        public City (string name, int population, double latitude, double longitude)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Argument '{nameof(name)}' cannot be empty!");
            if (population < 0) throw new ArgumentException($"Argument '{nameof(population)}' cannot be negative!");

            Name = name;
            ChangeInfo(name, population, latitude, longitude);
        }

        public IEnumerable<Hotel> Hotels
        {
            get { return _hotels; }
        }

        public void ChangeName(string name)
        {
            if(name != null)
                Name = name;
        }

        public void ChangeInfo(string name, int population, double latitude, double longitude)
        {

            ChangeName(name);
            ChangeLatitudeLongitude(latitude, longitude);
            ChangeAmountOfPopulation(population);
        }

        public void AddHotel(
            string name,
            HotelRating hotelRating,
            int roomsCount,
            string comment = null)
        {
            if (_hotels.Any(h => h.Name == name))
            {
                //throw
            }

            var hotel = new Hotel(
                name,
                hotelRating,
                roomsCount,
                comment);

            _hotels.Add(hotel);
        }

        public void Removehotel(Hotel hotel)
        {
            if(_hotels.Contains(hotel))
                _hotels.Remove(hotel);
            else
                return;
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