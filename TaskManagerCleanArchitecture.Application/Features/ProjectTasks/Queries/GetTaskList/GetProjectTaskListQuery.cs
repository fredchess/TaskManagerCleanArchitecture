using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskList
{
    public class GetProjectTaskListQuery : IRequest<List<ProjectTaskListViewModel>>
    {
    }
}
