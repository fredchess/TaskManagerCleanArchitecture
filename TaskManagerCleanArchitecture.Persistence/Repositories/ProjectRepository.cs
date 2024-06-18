using Microsoft.EntityFrameworkCore;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks;
using TaskManagerCleanArchitecture.Application.Requests;
using TaskManagerCleanArchitecture.Domain.Entities;
using TaskManagerCleanArchitecture.Persistence.Extensions;

namespace TaskManagerCleanArchitecture.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        public ProjectRepository(ApplicationDbContext dbContext, IUserService userService, IProjectTaskRepository projectTaskRepository) : base(dbContext, userService)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<int> GetProjectTasksCountAsync(Guid id)
        {
            var connectedUser = await _userService.GetConnectedUser();

            return await _dbContext.ProjectTasks.Where(t => t.ProjectId == id && connectedUser.Id == t.UserId).CountAsync();
        }

        public async Task<Project?> GetProjectWithTasks(Guid id)
        {
            var project = await _dbContext.Set<Project>()
                            .Include(p => p.ProjectTasks)
                            .Where(p => p.Id == id)
                            .FirstOrDefaultAsync();

            if (project == null)
                return null;

            var connectedUser = await _userService.GetConnectedUser();
            var tasks = project.ProjectTasks = project.ProjectTasks.Where(t => t.UserId == connectedUser.Id).ToList();

            project.ProjectTasks = tasks;

            return project;
        }

        public async Task<Project?> GetProjectWithTasks(GetProjectWithTasksQuery parameters)
        {
            var project = await _dbContext.Projects
                            .Where(p => p.Id == parameters.Id)
                            .FirstOrDefaultAsync();

            if (project == null)
                return null;

            var connectedUser = await _userService.GetConnectedUser();
            
            var tasks = await _dbContext.ProjectTasks
                        .Where(t => t.UserId == connectedUser.Id && t.ProjectId == parameters.Id)
                        .Filter(parameters)
                        .SortBy(parameters)
                        .Skip(parameters.Limit * (parameters.Page - 1))
                        .Take(parameters.Limit)
                        .ToListAsync();

            project.ProjectTasks = tasks;

            return project;
        }
    }
}