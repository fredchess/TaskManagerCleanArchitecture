using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskDetail;
using TaskManagerCleanArchitecture.Application.Responses;
using TaskManagerCleanArchitecture.Domain.Enums;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.CreateTask
{
	public class CreateProjectTaskCommand : IRequest<BaseResponse<ProjectTaskDetailViewModel>>
	{
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; }
		public ProjectTaskStatusEnum Status { get; set; }
		public int Priority { get; set; }
		public DateTime DueDate { get; set; }
        public Guid ProjectId { get; set; }
    }
}
