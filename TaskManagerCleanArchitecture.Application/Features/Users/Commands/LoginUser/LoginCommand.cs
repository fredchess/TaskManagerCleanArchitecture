using MediatR;

namespace TaskManagerCleanArchitecture.Application.Features.Users.Commands.LoginUser
{
    public class LoginCommand : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}