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

namespace DevFreela.Application.Queries.GetAllSkills
{
	public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
	{
		private readonly ISkillRepository _skillRepository;
		
		public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
		{
			_skillRepository = skillRepository;
		}
		
		public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
		{
			var skills =  await _skillRepository.GetAll();

            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skillsViewModel;
		}
	}
}