using Core.Generic;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Interfaces.Generic
{
    public interface IGenericRepository<TEntity, TId> where TEntity : class, IGenericEntity<TId>
    {
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<List<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<TEntity> GetById(TId id);
        Task Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task Delete(TId id);
        void Save();
    }
}
