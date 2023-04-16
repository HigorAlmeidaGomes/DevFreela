using DevFreela.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, string skills, string ownedProjects)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills;
            OwnedProjects = ownedProjects;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime CreateAt { get; private set; }

        public string Skills { get; private set; }

        public string OwnedProjects { get; private set; }

    }
}
