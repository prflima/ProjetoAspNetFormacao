using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateProject
{
	public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
	{
		private readonly DevFreelaDbContext _dbContext;
		
		public UpdateProjectCommandHandler(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
		{
			var project = _dbContext.Projects.FirstOrDefault(p => p.Id == request.Id);
			project.Update(request.Title, request.Description, request.TotalCoast);
			
			await _dbContext.SaveChangesAsync();
			return Unit.Value;
		}
	}
}