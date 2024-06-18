using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(ApplicationUser user);
        Task<ApplicationUser> ValidateToken(string token);
    }
}