using Microsoft.AspNetCore.Mvc;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	[ApiController]
	[Route("api/projects")]
	public class ProjectController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult> GetProjects()
		{
			return Ok();
		}

		[HttpGet("{id}/tasks")]
		public async Task<ActionResult> GetProjectTasks(Guid id)
		{
			return Ok();
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
