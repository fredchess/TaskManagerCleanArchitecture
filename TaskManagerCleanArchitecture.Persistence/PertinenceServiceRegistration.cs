using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Persistence
{
	public static class PertinenceServiceRegistration
	{
		public static IServiceCollection AddPertinenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(opt => {
				opt.UseMySql(configuration.GetConnectionString("Mysql"), ServerVersion.AutoDetect(configuration.GetConnectionString("Mysql")));
			});

			return services;

		}
	}
}
