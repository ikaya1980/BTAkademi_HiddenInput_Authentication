using Microsoft.EntityFrameworkCore;
using ornekWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ornekWeb.Data
{
    public class SqlFirmData : IEntityData<Firm>
    {
        private readonly WebDbContext _context;
        public SqlFirmData(WebDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Firm> GetAll()
        {
            return _context.firms.OrderBy(i => i.FirmId);
        }

        public Firm GetById(int entityId)
        {
            return _context.firms.Find(entityId);
        }

        public IEnumerable<Firm> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Firm entity)
        {
            _context.Add(entity);
        }

        public Firm Update(Firm entity)
        {
            var myentity = _context.firms.Attach(entity);
            myentity.State = EntityState.Modified;
            return entity;
        }
        public void Delete(int entityId)
        {
            Firm entity = _context.firms.Find(entityId);
            _context.Remove(entity);
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
