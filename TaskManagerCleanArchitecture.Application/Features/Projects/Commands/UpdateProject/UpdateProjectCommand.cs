using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.UpdateProject
{
	public class UpdateProjectCommand : IRequest<bool>
	{
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
