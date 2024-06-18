namespace TaskManagerCleanArchitecture.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
    }
}