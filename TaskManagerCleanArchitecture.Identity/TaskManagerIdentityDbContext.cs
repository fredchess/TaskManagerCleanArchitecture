using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Identity.Models;

namespace TaskManagerCleanArchitecture.Identity
{
	public class TaskManagerIdentityDbContext : DbContext
	{
		public TaskManagerIdentityDbContext()
		{ }

		public TaskManagerIdentityDbContext(DbContextOptions<TaskManagerIdentityDbContext> options) : base(options)
		{ }
	}
}
