using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticleCategoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ArticleCategory GetByKey(string stringKey)
        {
            ArticleCategory result = _dbContext.ArticleCategories.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            return result;
        }

        public ArticleCategory GetById(int id)
        {
            ArticleCategory result = _dbContext.ArticleCategories.FirstOrDefault(_ => _.Id == id);
            return result;
        }

        public IList<ArticleCategory> GetAll()
        {
            IQueryable<ArticleCategory> result = _dbContext.ArticleCategories;
            return result.ToList();
        }

        public IList<TResult> GetAll<TResult>(Expression<Func<ArticleCategory, TResult>> selector)
        {
            IQueryable<TResult> result = _dbContext.ArticleCategories.Select(selector);
            return result.ToList();
        }

        public ArticleCategory Update(int id, Action<ArticleCategory> update)
        {
            ArticleCategory old = _dbContext.ArticleCategories.FirstOrDefault(_ => _.Id == id);
            if (old == null)
            {
                return null;
            }
            update(old);
            _dbContext.SaveChanges();
            return old;
        }

        public ArticleCategory Add(ArticleCategory entity)
        {
            _dbContext.ArticleCategories.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            ArticleCategory entity = _dbContext.ArticleCategories.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.ArticleCategories.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}