using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks;
using TaskManagerCleanArchitecture.Application.Requests;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Persistence
{
	public interface IProjectRepository : IAsyncRepository<Project>
	{
		Task<Project?> GetProjectWithTasks(Guid id);
		Task<Project?> GetProjectWithTasks(GetProjectWithTasksQuery parameters);
		Task<int> GetProjectTasksCountAsync(Guid id);
	}
}
