using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks
{
	public class GetProjectWithTasksQuery : IRequest<ProjectWithTasksViewModel>
	{
        public Guid Id { get; set; }
    }
}
