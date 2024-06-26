﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Infrastructure
{
	public interface IUserService
	{
		Task<ApplicationUser> GetConnectedUser();
	}
}
