using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject
{
	public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
	{
        public CreateProjectValidator()
        {
            RuleFor(p => p.Title).NotEmpty()
                .MinimumLength(5).WithMessage("The project name should have a minimun of 5 characters");
        }
    }
}
