﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);

        int Create(NewProjectInputModel newProjectInputModel);

        void Update(UpdateProjectInputModel updateProjectInputModel);

        void Delete(int id);
        void Finish(int id);

        void Start(int id);

        void CreateComment(CreateCommentInputModel creatCommentInputModel);

    }
}
