using DevFreela.Application.InputModels;
using DevFreela.Core.Entites;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CommandsProject.CreateComment
{
    public class CreateProjectCommentCommandHandler : IRequestHandler<CreateProjectCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateProjectCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment
                (
                request.content,
                request.idProject,
                request.idUser
                );

            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
