using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entites;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel newProjectInputModel)
        {
            try
            {

                var project = new Project
                (
                 newProjectInputModel.IdClient,
                 newProjectInputModel.IdFreelancer,
                 newProjectInputModel.Title,
                 newProjectInputModel.Description,
                 newProjectInputModel.TotalCost
                );
                _dbContext.Projects.Add(project);
                _dbContext.SaveChanges();
                return project.Id;
            }
            catch (Exception ex)
            {
                var path = Path.GetFullPath($"Erro At Create Project.txt");
                var texto = $"{DateTime.Now} => Erro - Mensagem: {ex.Message} \r\\n\" StackTrace {ex.StackTrace}";
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, texto);
                }
                else
                {
                    File.AppendAllText(path, texto);
                }
                throw;
            }
        }

        public void CreateComment(CreateCommentInputModel creatCommentInputModel)
        {
            var comment = new ProjectComment
                (
                creatCommentInputModel.content,
                creatCommentInputModel.idProject,
                creatCommentInputModel.idUser
                );
            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Cancel();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Finish();

            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            return _dbContext.Projects.Select(x => new ProjectViewModel(x.Id, x.Title, x.CreateAt)).ToList();
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            if (project == null) return null;
            else return new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt);
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Start();

            _dbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputModel updateProjectInputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == updateProjectInputModel.Id);

            project.Update(updateProjectInputModel.Title, updateProjectInputModel.Description, updateProjectInputModel.TotalCost);

            _dbContext.SaveChanges();
        }
    }
}
