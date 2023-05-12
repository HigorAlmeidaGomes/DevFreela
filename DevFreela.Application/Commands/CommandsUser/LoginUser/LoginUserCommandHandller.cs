using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CommandsUser.LoginUser
{
    public class LoginUserCommandHandller : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandller(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utilizar o mesmo algoritimo para criar o hash da senha
            var passwordHash = _authService.ComputeSha256Has(request.Password);
            // Buscar no banco um usuário que tenha o e-mail e a senha em formato de hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            // Se não existir lançar erro no login;
            if (user == null) { return null; }
            // Retornar o login com o token
            var token = _authService.GenarateJwtToken(user.Email, user.Role);
            return new LoginUserViewModel(user.Email, token);
        }
    }
}
