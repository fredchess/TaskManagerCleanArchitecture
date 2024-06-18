using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Application.Responses;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject
{
	public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, BaseResponse<CreateProjectDto>>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public CreateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
		{
			_mapper = mapper;
			_projectRepository = projectRepository;
		}

		public async Task<BaseResponse<CreateProjectDto>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateProjectValidator();
			var validationResult = await validator.ValidateAsync(request);
			var response = new BaseResponse<CreateProjectDto>();

			if (validationResult.Errors.Count > 0)
			{
				response.Success = false;
				response.StatusCode = (int) HttpStatusCode.UnprocessableEntity;

				foreach (var error in validationResult.Errors)
				{
					response.ValidationErrors.Add(error.ErrorMessage);
				}
			}

			if (response.Success) { 
				var project = await _projectRepository.CreateAsync(_mapper.Map<Project>(request));
				var projectDto = _mapper.Map<CreateProjectDto>(project);

				response.Data = projectDto;
			}

			return response;
		}
	}
}
