using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Infrastructure.Authentication
{
	public class UserService : IUserService
	{
		private readonly IHttpContextAccessor _httpContext;
		private readonly IUserRepository _userRepository;

		public UserService(IHttpContextAccessor httpContext, IUserRepository userRepository)
		{
			_httpContext = httpContext;
			_userRepository = userRepository;
		}

		public async Task<ApplicationUser> GetConnectedUser()
		{
			string email = (_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value) ?? throw new BadRequestException("Invalid user");
			var user = await _userRepository.GetByEmail(email);

			if (user == null)
				throw new BadRequestException("Invalid user");

			return user;
		}
	}
}
