using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject
{
	public class CreateProjectCommandResponse : BaseResponse
	{
		public CreateProjectDto Project { get; set; } = default!;

        public CreateProjectCommandResponse() : base()
		{ }
	}
}
