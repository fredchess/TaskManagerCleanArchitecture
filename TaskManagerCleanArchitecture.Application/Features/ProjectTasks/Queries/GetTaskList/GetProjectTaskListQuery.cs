using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Requests;

namespace TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Queries.GetTaskList
{
    public class GetProjectTaskListQuery : ProjectTaskParameters, IRequest<List<ProjectTaskListViewModel>>
    {
    }
}
