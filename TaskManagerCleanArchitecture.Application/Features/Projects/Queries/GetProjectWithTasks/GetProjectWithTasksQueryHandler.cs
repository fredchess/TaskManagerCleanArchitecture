using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskList;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks
{
	public class GetProjectWithTasksQueryHandler : IRequestHandler<GetProjectWithTasksQuery, BaseResponse<PaginatedResponse<ProjectTaskListViewModel>>>
	{
		private readonly IProjectRepository _projectRepository;
		private readonly IMapper _mapper;

		public GetProjectWithTasksQueryHandler(IMapper mapper, IProjectRepository projectRepository)
		{
			_mapper = mapper;
			_projectRepository = projectRepository;
		}

		public async Task<BaseResponse<PaginatedResponse<ProjectTaskListViewModel>>> Handle(GetProjectWithTasksQuery request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetProjectWithTasks(request);

			if (project == null)
			{
				throw new NotFoundException("Project not found.");
			}

			var tasks = _mapper.Map<List<ProjectTaskListViewModel>>(project.ProjectTasks);

			var data = new PaginatedResponse<ProjectTaskListViewModel> {
				Datas = tasks,
				Limit = request.Limit,
				Page = request.Page,
				TotalData = await _projectRepository.GetProjectTasksCountAsync(project.Id)
			};

			return new BaseResponse<PaginatedResponse<ProjectTaskListViewModel>> { Data = data };
		}
	}
}
