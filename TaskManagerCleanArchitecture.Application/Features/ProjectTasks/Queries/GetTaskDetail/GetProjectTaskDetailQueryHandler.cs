using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTask.Queries.GetTaskDetail
{
    public class GetProjectTaskDetailQueryHandler : IRequestHandler<GetProjectTaskDetailQuery, ProjectTaskDetailViewModel>
    {
        private readonly ProjectTaskRepository _projectTaskRepository;
        private readonly IMapper _mapper;

        public GetProjectTaskDetailQueryHandler(IMapper mapper, ProjectTaskRepository projectTaskRepository)
        {
            _mapper = mapper;
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<ProjectTaskDetailViewModel> Handle(GetProjectTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var projectTask = await _projectTaskRepository.GetByIdAsync(request.Id);

            return _mapper.Map<ProjectTaskDetailViewModel>(projectTask);
        }
    }
}
