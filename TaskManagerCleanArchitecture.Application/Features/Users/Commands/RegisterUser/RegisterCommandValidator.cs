using FluentValidation;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;

namespace TaskManagerCleanArchitecture.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Email field is not a valid email address.")
            .MustAsync(IsUniqueEmail).WithMessage("Email already exists.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(5).WithMessage("The password should have a minimun of 5 characters");
        }

        private async Task<bool> IsUniqueEmail(string email, CancellationToken token)
        {
            return !await _userRepository.VerifyIsUnique(email);
        }
    }
}