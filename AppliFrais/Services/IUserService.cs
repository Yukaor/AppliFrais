using AppliFrais.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.Services
{
    public interface IUserService
    {
        List<User> GetUsers();

        List<User> GetUsers(string metier);

        User GetUser(int id);

        User GetUser(string login, string password);

        void AddUser(User user);

        void EditUser(User oldUser, User newUser);

        void DeleteUser(User user);
    }
}
