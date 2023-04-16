using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entites;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(UserInputModel userInput)
        {
            var user = new User(userInput.FullName, userInput.Email, userInput.BirthDate);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users
                .Include(x => x.Skills)
                .Include(x => x.OwnedProjects)
                .SingleOrDefault(x => x.Id == id);

            var userViewModel = new UserViewModel(user.FullName, user.Email, user.BirthDate,
                user.Skills.FirstOrDefault(x => x.IdUser == id).Id.ToString(),
                user.OwnedProjects.FirstOrDefault(p => p.IdClient == id).Title.ToString());
           
            return userViewModel;
        }

        public User Login(int id, UserInputModel userInput)
        {
            throw new NotImplementedException();
        }
    }
}
