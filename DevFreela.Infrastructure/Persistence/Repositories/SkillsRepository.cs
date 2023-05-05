using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly string _connectionString;

        public SkillsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            using var connectionDb = new SqlConnection(_connectionString);
            connectionDb.Open();

            var scritp = "SELECT Id,Description FROM TB_SKILL;";
            var skills = await connectionDb.QueryAsync<SkillDTO>(scritp);
            return skills.ToList();
        }
    }
}
