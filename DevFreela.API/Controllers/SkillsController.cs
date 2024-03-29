using System.Threading.Tasks;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
	[Authorize]
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