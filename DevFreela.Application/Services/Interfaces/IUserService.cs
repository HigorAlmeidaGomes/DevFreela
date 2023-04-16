using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entites;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        int Create(UserInputModel user);

        User Login(int id, UserInputModel user);
    }
}
