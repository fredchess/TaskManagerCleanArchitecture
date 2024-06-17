using MediatR;

namespace TaskManagerCleanArchitecture.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterCommand : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}