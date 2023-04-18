using DevFreela.API.Models;
using DevFreela.Application.Commands.CommandsUser.CreateUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public UsersController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }
        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Por favor informe o id do usuário. ");
            }
            else
            {
                var user = _userService.GetById(id);
                if (user == null)
                {
                    return BadRequest("Usuário não  encontrado.");
                }
                else
                {
                    return Ok(user);
                }
            }
        }

        // api/users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand userCommand)
        {
            if (string.IsNullOrEmpty(userCommand.Email) && !string.IsNullOrEmpty(userCommand.FullName) && userCommand.BirthDate.Date == DateTime.Now.Date)
            {
                return BadRequest("Dados do usuário invalido");
            }
            else
            {
                // Cadastrar o usuário
                var id = await _mediator.Send(userCommand);
                if (id > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id }, userCommand);
                }
                else { return NotFound(id); }
            }
        }

        // api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
