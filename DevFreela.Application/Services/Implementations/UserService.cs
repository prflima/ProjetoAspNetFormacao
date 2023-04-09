using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly DevFreelaDbContext _dbContext;
		public UserService(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		public int Create(NewUserInputModel inputModel)
		{
			throw new NotImplementedException();
		}

		public UserDetailsViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Login(int id, LoginInputModel inputModel)
		{
			throw new NotImplementedException();
		}
	}
}