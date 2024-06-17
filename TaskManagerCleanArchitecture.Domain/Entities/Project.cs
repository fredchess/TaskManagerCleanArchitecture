using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Domain.Entities
{
	public class Project
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IList<ProjectTask> ProjectTasks { get; set; }
    }
}
