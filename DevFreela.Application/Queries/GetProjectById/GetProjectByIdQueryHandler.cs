using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectById
{
	public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
	{
		private readonly IProjectRepository _projectRepository;
		
		public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;	
		}
		
		public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
		{
			var project = await _projectRepository.GetById(request.Id);

			if (project == null) return null;

			var projectDetails = new ProjectDetailsViewModel(project.Id, project.Title,
								project.Description, project.TotalCoast, project.StartedAt,
								project.FinishedAt, project.Client.FullName, project.Freelancer.FullName);

			return projectDetails;
		}
	}
}