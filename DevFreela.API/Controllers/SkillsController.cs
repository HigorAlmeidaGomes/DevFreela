using DevFreela.Application.Queries.GetSkills.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
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
            // Buscar todos ou filtrar
            var query = new GetAllSkillsQuery();

            var skills = await _mediator.Send(query);

            if (skills.Any()) return Ok(skills);
            else return BadRequest();
        }
    }
}
