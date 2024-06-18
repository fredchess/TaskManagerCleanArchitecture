using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.CreateTask;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.DeleteTask;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.UpdateTask;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskDetail;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskList;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	[ApiController]
	[Route("api/tasks")]
	[Authorize]
	public class ProjectTaskController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProjectTaskController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<IList<ProjectTaskListViewModel>>> GetTasks([FromQuery] GetProjectTaskListQuery query)
		{
			var result = await _mediator.Send(query);

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProjectTaskDetailViewModel>> GetTask(Guid id)
		{
			var result = await _mediator.Send(new GetProjectTaskDetailQuery { Id = id });

			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> PostTask(CreateProjectTaskCommand command)
		{
			var result = await _mediator.Send(command);

			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Guid>> PutTask([FromRoute] Guid id, UpdateTaskCommand request)
		{
			request.Id = id;
			var result = await _mediator.Send(request);

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTask([FromRoute] Guid id)
		{
			var request = new DeleteTaskCommand() { Id = id };

			var result = await _mediator.Send(request);

			return Ok(result);
		}
	}
}
