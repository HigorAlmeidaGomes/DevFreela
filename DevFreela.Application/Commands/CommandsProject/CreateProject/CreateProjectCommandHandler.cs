using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CommandsProject.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _IProjectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _IProjectRepository = projectRepository;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            (
                 request.IdClient,
                 request.IdFreelancer,
                 request.Title,
                 request.Description,
                 request.TotalCost
                );

            await _IProjectRepository.AddAsync(project);
            return project.Id;
        }
    }
}
