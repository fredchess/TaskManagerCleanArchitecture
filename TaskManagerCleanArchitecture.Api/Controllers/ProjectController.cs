using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectList;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	[ApiController]
	[Route("api/projects")]
	public class ProjectController : ControllerBase
	{
		private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
		public async Task<ActionResult<IList<ProjectListViewModel>>> GetProjects()
		{
			var result = await _mediator.Send(new GetProjectListQuery());
			return Ok(result);
		}

		[HttpGet("{id}/tasks")]
		public async Task<ActionResult<ProjectWithTasksViewModel>> GetProjectTasks(Guid id)
		{
			var result = await _mediator.Send(new GetProjectWithTasksQuery() { Id = id });
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<CreateProjectCommandResponse>> PostProject(CreateProjectCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> PutProject(Guid id)
		{
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteProject(Guid id)
		{
			return Ok();
		}
	}
}
