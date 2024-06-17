using TaskManagerCleanArchitecture.Application.Features.Users.Commands.LoginUser;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<bool> VerifyIsUnique(string email);
        Task<ApplicationUser> CreateUserAsync(ApplicationUser user);
        Task<bool> ValidateCredentials(LoginCommand user);
    }
}