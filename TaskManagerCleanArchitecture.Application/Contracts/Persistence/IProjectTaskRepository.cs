﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCleanArchitecture.Application.Features.ProjectTasks.Commands.UpdateTask;
using TaskManagerCleanArchitecture.Application.Requests;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Contracts.Persistence
{
	public interface IProjectTaskRepository : IAsyncRepository<ProjectTask>
	{
		Task<IList<ProjectTask>> GetAllAsync(ProjectTaskParameters parameters);
	}
}
