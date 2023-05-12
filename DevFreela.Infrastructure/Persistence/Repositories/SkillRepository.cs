using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
	public class SkillRepository : ISkillRepository
	{
		private readonly DevFreelaDbContext _dbContext;
		
		public SkillRepository(DevFreelaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<Skill>> GetAll()
		{
			return await _dbContext.Skills.ToListAsync();
		}
	}
}