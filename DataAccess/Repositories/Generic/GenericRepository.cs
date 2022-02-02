using Core.Generic;
using DataAccess;
using Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Infrastructure.DataAccess.Repositories.Generic
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class, IGenericEntity<TId>
    {
        protected readonly HICDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(HICDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual async Task Delete(TId id)
        {
            Delete(await GetById(id));
        }

        public virtual Task<List<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToListAsync();
        }

        public virtual Task<List<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return (include != null) ? include(_dbSet).ToListAsync() : _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(TId id)
        {
            return await _dbSet.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public virtual async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);


        }


        public void Update(TEntity entityToUpdate)
        {
            if (_context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }


        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
