using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(ApplicationUser user);
        bool ValidateToken(string token);
    }
}