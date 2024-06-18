using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerCleanArchitecture.Application.Features.Users.Commands.LoginUser;
using TaskManagerCleanArchitecture.Application.Features.Users.Commands.RegisterUser;

namespace TaskManagerCleanArchitecture.Api.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register", Name = "RegisterUsers")]
		public async Task<ActionResult> Register(RegisterCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPost("login")]
		public async Task<ActionResult> Login(LoginCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet("manage/info"), Authorize]
		public ActionResult ManageInfo()
		{
			var email = User.FindFirst(ClaimTypes.NameIdentifier);
			
			if (email == null)
				return Unauthorized();

			return Ok(new {
				Email = email.Value
			});
		}
	}
}
