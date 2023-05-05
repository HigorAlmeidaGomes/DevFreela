using Dapper;
using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetSkills.GetAllSkills
{
    public class GetAllSkillsQueryHandller : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
    {
        private readonly ISkillsRepository _skillsRepository;

        public GetAllSkillsQueryHandller(ISkillsRepository skillsRepository)
        {
            _skillsRepository = skillsRepository;
        }

        public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            //return _dbContext.Skills.Select(x => new SkillViewModel(x.Id, x.Description)).ToList();
            var skills = await _skillsRepository.GetAllAsync();
            var skillsDto = skills.Select(x => new SkillDTO { Id = x.Id, Description = x.Description }).ToList();
            return skillsDto;
        }
    }
}
