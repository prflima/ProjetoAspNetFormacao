using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
	{
		private readonly IUserRepository _userRepository;
		
		public CreateUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = new User(request.FullName, request.Email, request.BirthDate, request.Active, request.Password, request.Role);
			
			await _userRepository.AddAsync(user);
			return user.Id;
		}
	}
}