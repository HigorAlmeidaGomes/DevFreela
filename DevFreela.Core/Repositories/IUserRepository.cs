using DevFreela.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email,string passwordHash);
    }
}
