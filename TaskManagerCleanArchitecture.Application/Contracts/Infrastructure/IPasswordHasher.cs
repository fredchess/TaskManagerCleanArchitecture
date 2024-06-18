using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IPasswordHasher
    {
        void HashPassword(string password, out byte[] salt, out byte[] hash);
        bool VerifyPassword(ApplicationUser user, string password);
    }
}