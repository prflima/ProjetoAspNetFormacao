using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
	[Authorize]
	public class ProjectsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ProjectsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		
		// api/projects?query=net core
		[HttpGet]
		[Authorize(Roles = "client, freelancer")]
		public async Task<IActionResult> Get()
		{
			var projects = await _mediator.Send(new GetAllProjectsQuery());
			return Ok(projects);
		}

		// api/projects/1
		[HttpGet("{id}")]
		[Authorize(Roles = "client, freelancer")]
		public async Task<IActionResult> GetById(int id)
		{
			var command = new GetProjectByIdQuery(id);
			
			var project = await _mediator.Send(command);
			
			if(project == null) return NotFound();
			
			return Ok(project);
		}

		// api/projects/1/comments
		[HttpPost("{id}/comments")]
		[Authorize(Roles = "client, freelancer")]
		public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
		{
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpPost]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
		{
			if (command.Title.Length > 50) return BadRequest();

			var id = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = id }, command);
		}

		// api/projects/2
		[HttpPut("{id}")]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
		{
			if (command.Description.Length > 200) return BadRequest();

			await _mediator.Send(command);
			
			return NoContent();
		}		

		// api/projects/3
		[HttpDelete("{id}")]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteProjectCommand(id);
			await _mediator.Send(command);

			return NoContent();
		}

		// api/projects/1/start
		[HttpPut("{id}/start")]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> Start(int id)
		{
			var command = new StartProjectCommand(id);
			await _mediator.Send(command);
			
			return NoContent();
		}

		// api/projects/1/finish
		[HttpPut("{id}/finish")]
		[Authorize(Roles = "client")]
		public async Task<IActionResult> Finish(int id)
		{
			var command = new FinishProjectCommand(id);
			await _mediator.Send(command);
			
			return NoContent();
		}
	}
}