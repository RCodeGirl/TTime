using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Content;
using Interfaces.Content;

namespace Services.Content
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Question Add(Question model)
        {
            _dbContext.Questions.Add(model);
            _dbContext.SaveChanges();
            return model;
        }

        public bool Delete(int id)
        {
            Question entity = _dbContext.Questions.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Questions.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Question> GetAll()
        {
            var result = _dbContext.Questions;
            return result.ToList();
        }

        public Question GetById(int id)
        {
            var entity = _dbContext.Questions.FirstOrDefault(_=>_.Id==id);
            return entity;
        }

        public Question Update(Question model)
        {
            _dbContext.Questions.Update(model);
            _dbContext.SaveChanges();
            return model;
        }
    }
}
