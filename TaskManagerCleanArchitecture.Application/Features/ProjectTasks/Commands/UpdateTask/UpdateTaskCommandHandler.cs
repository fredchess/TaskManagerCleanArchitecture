using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Domain.Entities;
using TaskManagerCleanArchitecture.Domain.Enums;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.UpdateTask
{
	public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Guid>
	{
		private readonly IProjectTaskRepository _projectTaskRepository;
		private readonly IMapper _mapper;

		public UpdateTaskCommandHandler(IMapper mapper, IProjectTaskRepository projectTaskRepository)
		{
			_mapper = mapper;
			_projectTaskRepository = projectTaskRepository;
		}

		public async Task<Guid> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
		{
			var task = await _projectTaskRepository.GetByIdAsync(request.Id);

			if (task == null)
			{
				throw new NotFoundException("Task not found");
			}

			if (task.DueDate <= DateTime.Now 
				&& request.Status == ProjectTaskStatusEnum.Completed 
				&& task.Status != ProjectTaskStatusEnum.Completed)
			{
				throw new BadRequestException("Passed Date you cannot mark as completed.");
			}

			task.DueDate = request.DueDate;
			task.Title = request.Title;
			task.Status = request.Status;
			task.Priority = request.Priority;

			await _projectTaskRepository.UpdateAsync(task);

			return request.Id;
		}
	}
}
