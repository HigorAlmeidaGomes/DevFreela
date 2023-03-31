using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entites;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var project = new Project
            (
             newProjectInputModel.IdClient,
             newProjectInputModel.IdFreelancer,
             newProjectInputModel.Title,
             newProjectInputModel.Description,
             newProjectInputModel.TotalCost
            );
            _dbContext.Projects.Add(project);
            return project.Id;
        }

        public void CreateComment(CreatCommentInputModel creatCommentInputModel)
        {
            var comment = new ProjectComment
                (
                creatCommentInputModel.content,
                creatCommentInputModel.idProject,
                creatCommentInputModel.idUser
                );
            _dbContext.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            return _dbContext.Projects.Select(x => new ProjectViewModel(x.Id,x.Title, x.CreateAt)).ToList();
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            return new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt);
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == id);
            project.Start();
        }

        public void Update(UpdateProjectInputModel updateProjectInputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == updateProjectInputModel.Id);

            project.Update(updateProjectInputModel.Title, updateProjectInputModel.Description, updateProjectInputModel.TotalCost);
        }
    }
}
