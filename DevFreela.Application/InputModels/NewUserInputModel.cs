using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Application.InputModels
{
    public class NewUserInputModel
    {
        public NewUserInputModel(string fullName, string email, DateTime birthDate, List<UserSkill> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            Active = true;
            Skills = skills ?? new List<UserSkill>();
        }

        public string FullName { get; private set; }
		public string Email { get; private set; }
		public DateTime BirthDate { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public bool Active { get; private set; }
		public List<UserSkill> Skills { get; private set; }
    }
}