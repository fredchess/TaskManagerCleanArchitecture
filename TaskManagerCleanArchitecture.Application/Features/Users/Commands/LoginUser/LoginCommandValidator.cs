using FluentValidation;

namespace TaskManagerCleanArchitecture.Application.Features.Users.Commands.LoginUser
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(5).WithMessage("The password should have a minimun of 5 characters");
        }
    }
}