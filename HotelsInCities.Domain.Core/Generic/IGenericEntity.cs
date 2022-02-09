namespace HotelsInCities.Domain.Core.Generic
{
    public interface IGenericEntity<T>
    {
        T Id { get; }
    }
}
