using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
	public class ProjectService : IProjectService
	{
		private readonly DevFreelaDbContext _dbContext;
		public ProjectService(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ProjectDetailsViewModel GetById(int id)
		{
			var project = _dbContext.Projects
							.Include(p => p.Client)
							.Include(p => p.Freelancer)
							.FirstOrDefault(p => p.Id == id);

			if (project == null) return null;

			var projectDetails = new ProjectDetailsViewModel(project.Id, project.Title,
								project.Description, project.TotalCoast, project.StartedAt,
								project.FinishedAt, project.Client.FullName, project.Freelancer.FullName);

			return projectDetails;
		}
	}
}