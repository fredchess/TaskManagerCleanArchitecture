using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskDetail
{
    public class GetProjectTaskDetailQuery : IRequest<ProjectTaskDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
