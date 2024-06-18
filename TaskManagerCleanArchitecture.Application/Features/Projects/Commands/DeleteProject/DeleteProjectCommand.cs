using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.DeleteProject
{
	public class DeleteProjectCommand : IRequest<BaseResponse<string>>
	{
        public Guid Id { get; set; }
    }
}
