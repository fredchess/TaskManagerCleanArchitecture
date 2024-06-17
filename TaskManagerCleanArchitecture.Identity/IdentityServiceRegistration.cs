using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Identity.Models;

namespace TaskManagerCleanArchitecture.Identity
{
	public static class IdentityServiceRegistration
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration conf)
		{
			var connectionString = conf.GetConnectionString("Mysql");

			services.AddDbContext<TaskManagerIdentityDbContext>(options => {
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});

			//services.AddIdentityCore<ApplicationUser>()
			//	.AddEntityFrameworkStores<TaskManagerIdentityDbContext>();

			return services;
		}
	}
}
