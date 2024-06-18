using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
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
			builder.Services.AddSwaggerGen(opt => {
				opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme { 
					In = ParameterLocation.Header,
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				opt.OperationFilter<SecurityRequirementsOperationFilter>();
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseCustomExceptionHandler();

			app.MapControllers();

			app.Run();
		}

		public static void AddServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(opt => {
					opt.TokenValidationParameters = new TokenValidationParameters {
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value)),
						ValidateIssuer = false,
						ValidateAudience = false
					};
				});

			services.AddHttpContextAccessor();
			services.AddPertinenceServices(configuration)
					.AddApplicationServices()
					.AddInfrastructureServices();
		}
	}
}
