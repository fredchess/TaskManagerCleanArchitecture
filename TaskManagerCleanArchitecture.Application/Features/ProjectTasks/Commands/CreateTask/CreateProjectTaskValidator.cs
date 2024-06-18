using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Domain.Enums;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.CreateTask
{
	public class CreateProjectTaskValidator : AbstractValidator<CreateProjectTaskCommand>
	{
        private readonly IProjectRepository _projectRepository;

		public CreateProjectTaskValidator(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;

			RuleFor(t => t.Title)
				.NotEmpty()
				.MinimumLength(5).WithMessage("Title must have a minimum of 5 caraters");

			RuleFor(t => t.Status)
				.IsInEnum().WithMessage("Invalid value for {PropertyName}");

			RuleFor(t => t.DueDate)
				.GreaterThan(DateTime.Now).WithMessage("You cannot create a task with a past date.");

			RuleFor(t => t.ProjectId).MustAsync(ProjectExists).WithMessage("Project Not found");
		}

		private async Task<bool> ProjectExists(Guid projectId, CancellationToken cancellationToken)
		{
			return await _projectRepository.GetByIdAsync(projectId) != null;
		}
	}
}
