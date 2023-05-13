using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
		public string Email { get; set; }
        public string Password { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool Active { get; set; }
    }
}