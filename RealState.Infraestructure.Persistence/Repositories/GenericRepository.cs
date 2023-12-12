using Microsoft.EntityFrameworkCore;
using RealState.Infraestructure.Persistence.Context;
using RealStateApp.Core.Application.Interface.Repositories;

namespace RealState.Infraestructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RealStateContext _dbContext;

        public GenericRepository(RealStateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).Property("IsDeleted").CurrentValue = true;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<List<T>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (string property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity, int id)
        {
            var entry = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }
    }

}
