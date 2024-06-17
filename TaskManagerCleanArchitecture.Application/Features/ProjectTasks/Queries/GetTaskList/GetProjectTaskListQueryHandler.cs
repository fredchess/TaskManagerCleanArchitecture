﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTask.Queries.GetTaskList
{
    public class GetProjectTaskListQueryHandler : IRequestHandler<GetProjectTaskListQuery, List<ProjectTaskListViewModel>>
    {
        private readonly ProjectTaskRepository _projectTaskRepository;
        private readonly IMapper _mapper;

        public GetProjectTaskListQueryHandler(ProjectTaskRepository projectTaskRepository, IMapper mapper)
        {
            _projectTaskRepository = projectTaskRepository;
            _mapper = mapper;
        }


        public async Task<List<ProjectTaskListViewModel>> Handle(GetProjectTaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _projectTaskRepository.GetAllAsync();

            return _mapper.Map<List<ProjectTaskListViewModel>>(tasks);
        }
    }
}
