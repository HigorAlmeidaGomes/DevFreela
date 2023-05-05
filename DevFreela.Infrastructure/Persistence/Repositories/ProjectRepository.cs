using Dapper;
using DevFreela.Core.Entites;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private string _configurationDb;
        public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configurationDb = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();
        }
        public async Task StartAsync(Project project)
        {
            var proj = _dbContext.Projects.SingleOrDefault(x => x.Id == project.Id);
            proj.Start();
            await _dbContext.SaveChangesAsync();

            using (var sqlConection = new SqlConnection(_configurationDb))
            {
                sqlConection.Open();
                var script = "UPDATE PROJECT SET STATUS = @STATUS, STARTEDAT @STARTEDAT WHERE ID = @ID";
                await sqlConection.ExecuteScalarAsync(script, new { project.Status, project.StartedAt, project.Id });
            }
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);

            await _dbContext.SaveChangesAsync();
        }
    }
}
