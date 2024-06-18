using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.UpdateTask;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.DeleteTask
{
	public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
	{
		private readonly IProjectTaskRepository _projectTaskRepository;
		private readonly IUserService _userService;

		public DeleteTaskCommandValidator(IUserService userService, IProjectTaskRepository projectTaskRepository)
		{
			_userService = userService;
			_projectTaskRepository = projectTaskRepository;

			RuleFor(u => u).MustAsync(BelongsToConnectedUser).WithMessage("You are not owner of this task.");
		}

		private async Task<bool> BelongsToConnectedUser(DeleteTaskCommand command, CancellationToken cancellationToken)
		{
			var connectedUser = await _userService.GetConnectedUser();
			var taskToUpdate = await _projectTaskRepository.GetByIdAsync(command.Id);

			return connectedUser.Id.Equals(taskToUpdate.UserId);
		}
	}
}
