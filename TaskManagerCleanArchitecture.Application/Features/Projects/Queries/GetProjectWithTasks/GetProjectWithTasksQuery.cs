using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Responses;
using TaskManagerCleanArchitecture.Application.Requests;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskList;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks
{
	public class GetProjectWithTasksQuery : ProjectTaskParameters, IRequest<BaseResponse<PaginatedResponse<ProjectTaskListViewModel>>>
	{
        public Guid Id { get; set; }
    }
}
