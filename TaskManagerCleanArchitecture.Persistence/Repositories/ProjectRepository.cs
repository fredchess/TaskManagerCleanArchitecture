using Microsoft.EntityFrameworkCore;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Project> GetProjectWithTasks(Guid id)
        {
            var project = await _dbContext.Set<Project>()
                            .Include(p => p.ProjectTasks)
                            .Where(p => p.Id == id)
                            .FirstOrDefaultAsync();

            return project;
        }
    }
}