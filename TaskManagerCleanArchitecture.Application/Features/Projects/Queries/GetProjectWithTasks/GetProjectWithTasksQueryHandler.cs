using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks
{
	public class GetProjectWithTasksQueryHandler : IRequestHandler<GetProjectWithTasksQuery, BaseResponse<ProjectWithTasksViewModel>>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public GetProjectWithTasksQueryHandler(IMapper mapper, IProjectRepository projectRepository)
		{
			_mapper = mapper;
			_projectRepository = projectRepository;
		}

		public async Task<BaseResponse<ProjectWithTasksViewModel>> Handle(GetProjectWithTasksQuery request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetProjectWithTasks(request.Id);

			return new BaseResponse<ProjectWithTasksViewModel> { Data = _mapper.Map<ProjectWithTasksViewModel>(project) };
		}
	}
}
