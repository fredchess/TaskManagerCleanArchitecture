using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.DeleteProject
{
	public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, BaseResponse<string>>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public DeleteProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
		{
			_mapper = mapper;
			_projectRepository = projectRepository;
		}

		public async Task<BaseResponse<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetByIdAsync(request.Id);
			await _projectRepository.DeleteAsync(project);

			return new BaseResponse<string>{ Data = request.Id.ToString() };
		}
	}
}
