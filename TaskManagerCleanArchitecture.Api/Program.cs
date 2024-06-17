using TaskManagerCleanArchitecture.Api.Middlewares;
using TaskManagerCleanArchitecture.Application;
using TaskManagerCleanArchitecture.Infrastructure;
using TaskManagerCleanArchitecture.Persistence;

namespace TaskManagerCleanArchitecture.Api
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			AddServices(builder.Services, builder.Configuration);

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseCustomExceptionHandler();

			app.MapControllers();

			app.Run();
		}

		public static void AddServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthorization();

			services.AddPertinenceServices(configuration)
					.AddApplicationServices()
					.AddInfrastructureServices();
		}
	}
}
