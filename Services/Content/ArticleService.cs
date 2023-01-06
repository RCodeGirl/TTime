using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Article GetByKey(string stringKey)
        {
            Article result = _dbContext.Articles.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            return result;
        }

        public Article GetByIdIncludeTags(int id)
        {
            Article result = _dbContext.Articles.FirstOrDefault(_ => _.Id == id);
            return result;
        }
        public Article GetById(int id)
        {
            Article result = _dbContext.Articles.FirstOrDefault(_ => _.Id == id);
            return result;
        }
        public IList<Article> GetAll(bool onlyActive = true)
        {
            IQueryable<Article> result =
                _dbContext.Articles.OrderByDescending(_ => _.Date).AsQueryable();
            if (onlyActive)
            {
                result = result.Where(_ => !_.IsHidden);
            }
            return result.ToList();
        }

        //public IList<Article> GetAllByCategoryKey(string stringKey, bool onlyActive = true)
        //{
        //    IQueryable<Article> result =
        //        _dbContext.Articles.Include(_ => _.Category)
        //                         .Where(_ => _.Category.StringKey.Equals(stringKey))
        //                         .OrderByDescending(_ => _.Date)
        //                         .AsQueryable();
        //    if (onlyActive)
        //    {
        //        result = result.Where(_ => !_.IsHidden);
        //    }
        //    return result.ToList();
        //}

        public IList<Article> GetLast(int count, bool onlyActive = true)
        {
            IQueryable<Article> result =
                _dbContext.Articles.OrderByDescending(_ => _.Date).AsQueryable();
            if (onlyActive)
            {
                result = result.Where(_ => !_.IsHidden);
            }
            result = result.Take(count);
            return result.ToList();
        }

        public Article Update(Article entity)
        {
            _dbContext.Articles.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Article Add(Article entity)
        {
            _dbContext.Articles.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Article entity = _dbContext.Articles.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Articles.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}