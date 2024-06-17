using Microsoft.Extensions.DependencyInjection;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Infrastructure.Authentication;

namespace TaskManagerCleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}