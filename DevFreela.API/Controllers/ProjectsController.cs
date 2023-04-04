using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // api/projects?query=net core
        [HttpGet]
        public IActionResult Get(string query)
        {
            // Buscar todos ou filtrar
            if (!String.IsNullOrEmpty(query))
                return Ok(_projectService.GetAll(query));
            else return BadRequest();
        }

        // api/projects/2
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Buscar o projeto
            if (id > 0)
            {
                var projectById = _projectService.GetById(id);
                if (projectById != null)
                {
                    return Ok(projectById);
                }
                else return NotFound();
            }
            else { return BadRequest(); }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 50)
            {
                return BadRequest();
            }
            else
            {
                // Cadastrar o projeto
                var id = _projectService.Create(inputModel);
                if (id > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id }, inputModel);
                }
                else { return NotFound(); }
            }

        }

        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProjectInputModel)
        {
            if (updateProjectInputModel.Description.Length > 200)
            {
                return BadRequest();
            }
            else
            {
                // Atualizo o objeto
                _projectService.Update(updateProjectInputModel);
                return NoContent();
            }
        }

        // api/projects/3 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar, se não existir, retorna NotFound
            var projectDelete = _projectService.GetById(id);

            if (projectDelete != null)
            {
                // Remover 
                _projectService.Delete(projectDelete.Id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createCommentInputModel)
        {
            if (createCommentInputModel.idUser > 0 && createCommentInputModel.idProject > 0)
            {
                _projectService.CreateComment(createCommentInputModel);
                return NoContent();
            }
            else { return BadRequest(); }
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            if (id > 0) _projectService.Start(id);
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            if (id > 0) _projectService.Finish(id);
            return NoContent();
        }
    }
}
