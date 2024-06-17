using Microsoft.EntityFrameworkCore;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;

namespace TaskManagerCleanArchitecture.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}