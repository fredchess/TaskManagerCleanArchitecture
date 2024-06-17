using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Persistence.Repositories
{
    public class ProjectTaskRepository : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}