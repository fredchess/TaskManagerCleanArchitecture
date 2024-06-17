using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Domain.Enums;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTask.Queries.GetTaskDetail
{
    public class ProjectTaskDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ProjectTaskStatusEnum Status { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}
