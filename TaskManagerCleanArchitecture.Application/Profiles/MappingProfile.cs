using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Features.Projects.Commands.CreateProject;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectList;
using TaskManagerCleanArchitecture.Application.Features.Projects.Queries.GetProjectWithTasks;
using TaskManagerCleanArchitecture.Application.Features.ProjectTask.Queries.GetTaskDetail;
using TaskManagerCleanArchitecture.Application.Features.ProjectTask.Queries.GetTaskList;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Profiles
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Project, ProjectListViewModel>()
				.ForMember(vm => vm.TotalTasks, opt => opt.MapFrom(src => src.ProjectTasks.Count))
				.ReverseMap();
			CreateMap<ProjectTask, ProjectTaskListViewModel>();
			CreateMap<ProjectTask, ProjectTaskDetailViewModel>();
			CreateMap<Project, ProjectWithTasksViewModel>();
			CreateMap<Project, CreateProjectCommand>().ReverseMap();
			CreateMap<Project, CreateProjectDto>().ReverseMap();
		}
	}
}
