using DevFreela.Application.Commands.CommandsUser.CreateUser;
using DevFreela.Application.Commands.CommandsUser.LoginUser;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand userCommand)
        {
            if (!ModelState.IsValid)
            {
                var mensagem = ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(mensagem);
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
        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var login = await _mediator.Send(command);

            if (login != null) { return Ok(login); } else { return BadRequest("Erro ao gerar o token"); }
        }
    }
}
