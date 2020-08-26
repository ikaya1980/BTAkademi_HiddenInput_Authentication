using ornekWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ornekWeb.Data
{
    public interface IEntityData<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int entityId);

        IEnumerable<T> GetByName(string Name);

        void Insert(T entity);

        T Update(T entity);

        void Delete(int entityId);

        int Commit();

    }

    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetById(int UserId);
        void AddUser(User entity);
        User GetByLogin(string UserEmail, string UserPassword);
     

        int Commit();
    }
}
