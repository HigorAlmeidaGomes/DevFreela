﻿using System;

namespace DevFreela.Core.Entites
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; private set; }

        public int IdProject { get; private set; }

        public int IdUser { get; private set; }

        public DateTime CreateAt { get; private set; }
    }
}