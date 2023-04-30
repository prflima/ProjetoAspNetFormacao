using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
	public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
	{
		private readonly DevFreelaDbContext _dbContext;
		
		public GetAllProjectsQueryHandler(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
		{
			var projects = _dbContext.Projects;

			var projectsViewModel = await projects
				.Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
				.ToListAsync();

			return projectsViewModel;
		}
	}
}