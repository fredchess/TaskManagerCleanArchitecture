using System.Security.Cryptography;
using System.Text;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Infrastructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public void HashPassword(string password, out byte[] salt, out byte[] hash)
        {
            using var hmac = new HMACSHA512();
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            salt = passwordSalt;
            hash = passwordHash;
        }

        public bool VerifyPassword(ApplicationUser user, string password)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
}