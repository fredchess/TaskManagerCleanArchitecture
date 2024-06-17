namespace TaskManagerCleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IPasswordHasher
    {
        byte[] HashPassword(string password);
        bool VerifyPassword(byte[] hashedPassword, string password);
    }
}