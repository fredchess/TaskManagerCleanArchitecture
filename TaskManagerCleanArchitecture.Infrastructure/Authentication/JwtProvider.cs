using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        public string GenerateToken(ApplicationUser user)
        {
            return "abcde";
        }

        public bool ValidateToken(string token)
        {
            return true;
        }
    }
}