using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
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
        public IActionResult Post([FromBody] UserInputModel createUserModel)
        {
            if (string.IsNullOrEmpty(createUserModel.Email) && !string.IsNullOrEmpty(createUserModel.FullName) && createUserModel.BirthDate.Date == DateTime.Now.Date)
            {
                return BadRequest("Dados do usuário invalido");
            }
            else
            {
                // Cadastrar o usuário
                var id = _userService.Create(createUserModel);
                if (id > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id }, createUserModel);
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
