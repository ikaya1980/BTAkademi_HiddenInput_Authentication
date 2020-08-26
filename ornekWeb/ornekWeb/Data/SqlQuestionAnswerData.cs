using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ornekWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace ornekWeb.Data
{

    public class SqlQuestionAnswerData : IEntityData<QuestionAnswer>
    {
        private readonly WebDbContext _context;
        public SqlQuestionAnswerData(WebDbContext context)
        {
            _context = context;
        }


        public IEnumerable<QuestionAnswer> GetAll()
        {
            return _context.questionanswers.OrderBy(i => i.questionAnswerId);
        }

        public QuestionAnswer GetById(int entityId)
        {
            return _context.questionanswers.Find(entityId);
        }

        public IEnumerable<QuestionAnswer> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public void Insert(QuestionAnswer entity)
        {
            _context.Add(entity);
        }

        public QuestionAnswer Update(QuestionAnswer entity)
        {
            var myentity = _context.questionanswers.Attach(entity);
            myentity.State = EntityState.Modified;
            return entity;
        }
        public void Delete(int entityId)
        {
            QuestionAnswer entity = _context.questionanswers.Find(entityId);
            _context.Remove(entity);
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

    }
}
