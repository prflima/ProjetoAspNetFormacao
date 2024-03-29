using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
	[Authorize]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}
		
		// api/users/1
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var command = new GetUserByIdQuery(id);
			
			var user = await _mediator.Send(command);
			
			if(user == null) return NotFound();
			
			return Ok(user);
		} 

		// api/users
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
		{			
			var id = await _mediator.Send(command);
			
			return CreatedAtAction(nameof(GetById), new { id = id}, command);
		}

		[HttpPut("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
		{
			var loginVM = await _mediator.Send(command);

			if(loginVM == null) return BadRequest("Usuário ou senha inválidos.");

			return Ok(loginVM);
		}
	}
}