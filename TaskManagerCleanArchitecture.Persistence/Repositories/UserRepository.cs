using Microsoft.EntityFrameworkCore;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Features.Users.Commands.LoginUser;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public UserRepository(ApplicationDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user)
        {
            var _user = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return _user.Entity;
        }

        public async Task<bool> ValidateCredentials(LoginCommand user)
        {
            var _user = await _dbContext.Users
                        .Where(u => u.Email == user.Email)
                        .FirstOrDefaultAsync();

            return _user != null && _passwordHasher.VerifyPassword(_user.Password, user.Password);
        }

        public async Task<bool> VerifyIsUnique(string email)
        {
            var user = await _dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();           

            return user != null;
        }
    }
}