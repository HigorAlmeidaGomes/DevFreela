using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjects
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAllAsync();
            var projectViewModel = project.Select(x => new ProjectViewModel(x.Id, x.Title, x.CreateAt)).ToList();
            return projectViewModel;
        }
    }
}
