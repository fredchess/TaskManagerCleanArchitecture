using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject
{
	public class CreateProjectCommand : IRequest<BaseResponse<CreateProjectDto>>
	{
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
