using DevFreela.Core.Entites;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project(1,1,"Projeto Consinco","Projeto de integração PDV SUP",1000),
                new Project(1,1,"Projeto Missauga","Projeto de integração Homer Center",1000),
                new Project(1,1,"Projeto 2075","Projeto de integração 2075",1000)
            };

            Users = new List<User>
            {
                new User("Higor Almeida Gomes","higor_hag@hotmail.com", new DateTime(1994,04,11)),
                new User("Hiago Almeida Gomes","hiago_hag@hotmail.com", new DateTime(1992,03,06)),
                new User("Flavio Borges","flavio_borges@hotmail.com", new DateTime(1983,04,11)),
            };

            Skills = new List<Skill>
            {
                new Skill("Dev C#"),
                new Skill("Adiminstrador"),
                new Skill("Product Owner")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
