using Microsoft.AspNetCore.Mvc;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	public class ProjectTaskController : Controller
	{
		[HttpGet]
		public async Task<ActionResult> GetTasks()
		{
			return Ok();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetTask(Guid id)
		{
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> PutTask(Guid id)
		{
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteTask(Guid id)
		{
			return Ok();
		}
	}
}
