using DevFreela.Core.Entites;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CommandsUser.CreateUser
{
    public class CreateUserCommandHandller : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandller(DevFreelaDbContext dbContext, IAuthService authService)
        {
            _dbContext = dbContext;
            _authService = authService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Has(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }
    }
}
