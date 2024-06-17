using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Contracts.Persistence
{
	public interface IAsyncRepository<T> where T : class
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetByIdAsync(Guid id);
		Task<T> CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
