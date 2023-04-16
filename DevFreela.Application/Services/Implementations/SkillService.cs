using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public List<SkillViewModel> GetAll()
        {
            //return _dbContext.Skills.Select(x => new SkillViewModel(x.Id, x.Description)).ToList();
            using (var connectionDb = new SqlConnection(_connectionString))
            {
                connectionDb.Open();

                var scritp = "SELECT Id,Description FROM TB_SKILL;";
                return connectionDb.Query<SkillViewModel>(scritp).ToList();
            }
        }
    }
}
