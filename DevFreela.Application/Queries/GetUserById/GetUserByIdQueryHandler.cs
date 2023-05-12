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

namespace DevFreela.Application.Queries.GetUserById
{
	public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
	{
		private readonly IUserRepository _userRepository;
		
		public GetUserByIdQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		
		public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetById(request.Id);
			
			if(user == null) return null;
			
			var userDetails = new UserDetailsViewModel(user.FullName, user.Email, user.BirthDate,
								user.Active, user.Skills);
								
			return userDetails;
		}
	}
}