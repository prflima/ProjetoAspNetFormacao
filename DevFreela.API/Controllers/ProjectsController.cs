using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
	public class ProjectsController : ControllerBase
	{
		private OpeningTimeOption _options;
		public ProjectsController(IOptions<OpeningTimeOption> options)
		{
			_options = options.Value;
		}
		
		// api/projects?query=net core
		[HttpGet]
		public IActionResult Get(string query)
		{
			// Necessary to implement the query search flow.

			return Ok();
		}

		// api/projects/1
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			// Need to implement the search flow by id

			return Ok();
		}

		[HttpPost]
		public IActionResult Post([FromBody] CreateProjectModel createProject)
		{
			if (createProject.Title.Length > 50) return BadRequest();

			// Necessary to implement the flow of creating a projectModel.

			return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
		}

		// api/projects/2
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
		{
			if (updateProject.Description.Length > 200) return BadRequest();

			// Need to implement the update flow.

			return NoContent();
		}

		// api/projects/3
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			// necessary to implement the flow to inactivate the projectModel

			return NoContent();
		}

		// api/projects/1/comments
		[HttpPost("{id}/comments")]
		public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
		{
			return NoContent();
		}

		// api/projects/1/start
		[HttpPut("{id}/start")]
		public IActionResult Start(int id)
		{
			return NoContent();
		}

		// api/projects/1/finish
		[HttpPut("{id}/finish")]
		public IActionResult Finish(int id)
		{
			return NoContent();
		}
	}
}