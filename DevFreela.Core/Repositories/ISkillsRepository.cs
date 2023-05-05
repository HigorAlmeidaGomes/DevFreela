using DevFreela.Core.DTOs;
using DevFreela.Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillsRepository
    {
        Task<List<SkillDTO>> GetAllAsync();
    }
}
