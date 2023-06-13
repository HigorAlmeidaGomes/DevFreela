using DevFreela.Application.Commands.CommandsProject.CreateComment;
using DevFreela.Application.Commands.CommandsProject.CreateProject;
using DevFreela.Application.Commands.CommandsProject.DeleteProject;
using DevFreela.Application.Commands.CommandsProject.StartProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;
        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            // Buscar todos ou filtrar
            if (!String.IsNullOrEmpty(query))
                return Ok(_projectService.GetAllAsync(query));
            else return BadRequest();
        }

        // api/projects/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Buscar o projeto
            if (id > 0)
            {
                var projectById = _projectService.GetByIdAsync(id);
                if (projectById != null)
                {
                    return Ok(projectById);
                }
                else return NotFound();
            }
            else { return BadRequest(); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }
            else
            {
                // Cadastrar o projeto
                var id = await _mediator.Send(inputModel);
                if (id > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id }, inputModel);
                }
                else { return NotFound(); }
            }
        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectCommand updateProjectCommand)
        {
            if (updateProjectCommand.Description.Length > 200)
            {
                return BadRequest();
            }
            else
            {
                // Atualizo o objeto
                _mediator.Send(updateProjectCommand);
                return NoContent();
            }
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            // Remover 
            await _mediator.Send(command);

            return NoContent();

        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateProjectCommentCommand command)
        {
            if (command.idUser > 0 && command.idProject > 0)
            {
                await _mediator.Send(command);
                return NoContent();
            }
            else { return BadRequest(); }
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            if (id > 0) await _mediator.Send(command);
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id, [FromBody] FinishProjectCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return (!result) ? BadRequest("Erro ao processar o pagamento") : NoContent();
        }
    }
}
