using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
	{
		private readonly DevFreelaDbContext _dbContext;
		
		public CreateUserCommandHandler(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = new User(request.FullName, request.Email, request.BirthDate, request.Active);
			
			await _dbContext.Users.AddAsync(user);
			await _dbContext.SaveChangesAsync();
			
			return user.Id;
		}
	}
}