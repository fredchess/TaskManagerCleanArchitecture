using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Responses;

namespace TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, BaseResponse<List<ProjectListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTaskRepository _projectTaskRepository;

        public GetProjectListQueryHandler(IProjectRepository projectRepository, IMapper mapper, IProjectTaskRepository projectTaskRepository)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<BaseResponse<List<ProjectListViewModel>>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            var vm = projects.Select(p => {
                var model = _mapper.Map<ProjectListViewModel>(p);
                model.TotalTasks = _projectRepository.GetProjectTasksCountAsync(p.Id).Result;
                return model;
            }).ToList();

            return new BaseResponse<List<ProjectListViewModel>> { Data = vm };
        }
    }
}
