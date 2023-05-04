using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public UserDetailsViewModel(string fullName, string email, DateTime birthDate, bool active, List<UserSkill> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = active;
            Skills = skills;
        }

        public string FullName { get; private set; }
		public string Email { get; private set; }
		public DateTime BirthDate { get; private set; }
		public bool Active { get; set; }
		public List<UserSkill> Skills { get; private set; }

    }
}