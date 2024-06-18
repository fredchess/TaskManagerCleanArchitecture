using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.DeleteTask
{
	public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, BaseResponse<string>>
	{
		private readonly IProjectTaskRepository _projectTaskRepository;
		private readonly IUserService _userService;

		public DeleteTaskCommandHandler(IProjectTaskRepository projectTaskRepository, IUserService userService)
		{
			_projectTaskRepository = projectTaskRepository;
			_userService = userService;
		}

		public async Task<BaseResponse<string>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
		{
			var task = await _projectTaskRepository.GetByIdAsync(request.Id);

			if (task == null)
				throw new NotFoundException("Task not found");

			var validator = new DeleteTaskCommandValidator(_userService, _projectTaskRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
				throw new ValidationException(validationResult);

			await _projectTaskRepository.DeleteAsync(task);

			return new BaseResponse<string>() {  Data	 = request.Id.ToString() };
		}
	}
}
