using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskDetail;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks
{
	public class ProjectWithTasksViewModel
	{
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public IList<ProjectTaskDetailViewModel> ProjectTasks { get; set; } = [];
    }
}
