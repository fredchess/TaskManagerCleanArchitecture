using System.Security.Cryptography;
using System.Text;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;

namespace TaskManagerCleanArchitecture.Infrastructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return passwordHash;
        }

        public bool VerifyPassword(byte[] hashedPassword, string password)
        {
            using var hmac = new HMACSHA512();
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(hashedPassword);
        }
    }
}