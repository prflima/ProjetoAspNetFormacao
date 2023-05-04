using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetUserById
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
	{
		private readonly DevFreelaDbContext _dbContext;
		
		public GetUserByIdQueryHandler(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _dbContext.Users
						.Include(us => us.Skills)
						.FirstOrDefaultAsync(us => us.Id == request.Id);
			
			if(user == null) return null;
			
			var userDetails = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate,
								user.Active, user.Skills);
								
			return userDetails;
		}
	}
}