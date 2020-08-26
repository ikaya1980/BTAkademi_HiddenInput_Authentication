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
}
