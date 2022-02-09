namespace HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IHotelRepository HotelRepository { get; }
        Task SaveChangesAsync();
    }
}
