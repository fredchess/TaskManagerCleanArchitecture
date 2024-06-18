using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject;
using TaskManagerCleanArchitecture.Application.Features.Projects.Commands.DeleteProject;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectList;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskDetail;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskList;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	[ApiController]
	[Route("api/projects")]
	[Authorize]
	public class ProjectController : ControllerBase
	{
		private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
		public async Task<ActionResult<BaseResponse<IList<ProjectListViewModel>>>> GetProjects()
		{
			var result = await _mediator.Send(new GetProjectListQuery());
			return Ok(result);
		}

		[HttpGet("{id}/tasks")]
		public async Task<ActionResult<BaseResponse<PaginatedResponse<ProjectTaskListViewModel>>>> GetProjectTasks([FromRoute] Guid id, [FromQuery] GetProjectWithTasksQuery query)
		{
			query.Id = id;

			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponse<ProjectTaskDetailViewModel>>> PostProject(CreateProjectCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<BaseResponse<string>>> DeleteProject(Guid id)
		{
			var request = new DeleteProjectCommand() { Id = id };
			var result = await _mediator.Send(request);

			return Ok(result);
		}
	}
}
