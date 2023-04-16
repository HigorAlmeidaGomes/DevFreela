using DevFreela.Core.Entites;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
