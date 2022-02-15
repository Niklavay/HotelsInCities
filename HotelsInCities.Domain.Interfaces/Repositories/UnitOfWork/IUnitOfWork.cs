namespace HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IHotelRepository HotelRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveChangesAsync();
    }
}
