using ornekWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ornekWeb.Data
{
    public class SqlUserData : IUserRepository
    {
        private WebDbContext _context { get; }


        public SqlUserData(WebDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public User GetByLogin(string UserEmail, string UserPassword)
        {
            return _context.Users.SingleOrDefault(i => i.UserEmail == UserEmail && i.UserPassword == UserPassword);
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }



    }
}
