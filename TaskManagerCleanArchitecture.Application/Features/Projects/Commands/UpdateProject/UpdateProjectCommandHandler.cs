using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.UpdateProject
{
	public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public UpdateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
		{
			_mapper = mapper;
			_projectRepository = projectRepository;
		}

		public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
		{
			//await _projectRepository.UpdateAsync(_mapper.Map<Project>(request));

			return true;
		}
	}
}
