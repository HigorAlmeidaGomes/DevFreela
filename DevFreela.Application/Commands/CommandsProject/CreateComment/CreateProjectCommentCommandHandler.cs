using DevFreela.Application.InputModels;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
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
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment
                (
                request.content,
                request.idProject,
                request.idUser
                );

            await _projectRepository.AddCommentAsync(comment);

            return Unit.Value;
        }
    }
}
