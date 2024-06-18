using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.UpdateTask;
using TaskManagerCleanArchitecture.Application.Requests;
using TaskManagerCleanArchitecture.Domain.Entities;
using TaskManagerCleanArchitecture.Persistence.Extensions;

namespace TaskManagerCleanArchitecture.Persistence.Repositories
{
    public class ProjectTaskRepository : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ApplicationDbContext dbContext, IUserService userService) : base(dbContext, userService)
        {
        }

        public async Task<IList<ProjectTask>> GetAllAsync(ProjectTaskParameters parameters)
        {
            var connectedUser = await _userService.GetConnectedUser();
            var tasks = await _dbContext.ProjectTasks.Where(t => t.UserId == connectedUser.Id)
                            .Filter(parameters)
                            .SortBy(parameters)
                            .Skip(parameters.Limit * (parameters.Page - 1))
                            .Take(parameters.Limit)
                            .ToListAsync();

            return tasks;
        }
    }
}