using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entites;
using DevFreela.Infrastructure.Persistence;
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
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            var userViewModel = new UserViewModel(user.FullName, user.Email, user.BirthDate);
            return userViewModel;
        }

        public User Login(int id, UserInputModel userInput)
        {
            throw new NotImplementedException();
        }
    }
}
