using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task AddAsync(User user);
        Task<User> GetByEmailAndPasswordAsync(string email, string passwordHash);
    }
}