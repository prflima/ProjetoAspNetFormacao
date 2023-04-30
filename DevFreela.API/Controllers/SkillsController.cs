using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevFreela.API.Controllers
{
	[Route("api/skills")]
	public class SkillsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SkillsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var skills = await _mediator.Send(new GetAllSkillsQuery());
			return Ok(skills);
		}
	}
}