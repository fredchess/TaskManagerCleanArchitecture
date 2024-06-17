using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Persistence
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{ 
			
		}

		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectTask> ProjectTasks { get; set; }
	}
}
