using Microsoft.AspNetCore.Mvc;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AuthController : ControllerBase
	{
		[HttpPost("register", Name = "Register Users")]
		public async Task<ActionResult> Register()
		{
			return Ok();
		}

		[HttpPost("login")]
		public async Task<ActionResult> Login()
		{
			return Ok();
		}
	}
}
