using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskDetail;
using TaskManagerCleanArchitecture.Application.Responses;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.CreateTask
{
	public class CreateProjectTaskCommandHandler : IRequestHandler<CreateProjectTaskCommand, BaseResponse<ProjectTaskDetailViewModel>>
	{
		private readonly IProjectTaskRepository _projectTaskRepository;
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public CreateProjectTaskCommandHandler(IMapper mapper, IProjectTaskRepository projectTaskRepository, IProjectRepository projectRepository, IUserService userService)
		{
			_mapper = mapper;
			_projectTaskRepository = projectTaskRepository;
			_projectRepository = projectRepository;
			_userService = userService;
		}

		public async Task<BaseResponse<ProjectTaskDetailViewModel>> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateProjectTaskValidator(_projectRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Count > 0)
				throw new ValidationException(validatorResult);

			var dto = _mapper.Map<ProjectTask>(request);
			dto.UserId = (await _userService.GetConnectedUser()).Id;

			var task = await _projectTaskRepository.CreateAsync(dto);

			var vm = _mapper.Map<ProjectTaskDetailViewModel>(task);

			return new BaseResponse<ProjectTaskDetailViewModel>() { Data = vm };
		}
	}
}
