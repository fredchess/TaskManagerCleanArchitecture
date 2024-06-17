using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Commands.DeleteProject
{
	public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public DeleteProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
		{
			_mapper = mapper;
			_projectRepository = projectRepository;
		}

		public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetByIdAsync(request.Id);
			await _projectRepository.DeleteAsync(project);

			return true;
		}
	}
}
