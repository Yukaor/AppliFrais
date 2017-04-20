using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppliFrais.EntityFramework.Models;
using AppliFrais.EntityFramework.Services;

namespace AppliFrais.Services
{
    public class UserService : IUserService
    {

        private readonly IBddContext _IBddContext;

        public UserService(IBddContext iBddContext)
        {
            _IBddContext = iBddContext;
        }

        public void AddUser(User user)
        {
            _IBddContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _IBddContext.Users.Remove(user);
        }

        public void EditUser(User oldUser, User newUser)
        {
            oldUser = newUser;
        }

        public User GetUser(int id)
        {
            return _IBddContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUser(string login, string password)
        {
            return _IBddContext.Users.FirstOrDefault(u => u.Username == login && u.Password == password);
        }

        public List<User> GetUsers()
        {
            return _IBddContext.Users.ToList<User>();
        }

        public List<User> GetUsers(string metier)
        {
            return _IBddContext.Users.Where(User => User.Metier == metier).ToList<User>();
        }

    }
}