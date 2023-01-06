using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainModel.Content;
using DomainModel.Navigation;
using Interfaces.Content;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class PageService : IPageService
    {
        private readonly ApplicationDbContext _dbContext;

        public PageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Page GetByKey(string stringKey)
        {
            var result = _dbContext.Pages.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            return result;
           
        }
        public IList<Page> GetPageByKey(string stringKey)
        {
            var pages = _dbContext.Pages.Where(_ => _.StringKey == stringKey).ToList();
            return pages;
        }

        public Page GetById(int id)
        {
            Page result = _dbContext.Pages.FirstOrDefault(_ => _.Id == id);
            return result;
        }

        public List<Page> GetAll()
        {
            DbSet<Page> result = _dbContext.Pages;
            return result.ToList();

        }

        public List<TResult> GetAll<TResult>(Expression<Func<Page, TResult>> selector)
        {
            IQueryable<TResult> result = _dbContext.Pages.Select(selector);
            return result.ToList();
        }

        public Page Update(int id, Action<Page> update)
        {
            Page old = _dbContext.Pages.FirstOrDefault(_ => _.Id == id);
            if (old == null)
            {
                return null;
            }
            update(old);
            _dbContext.SaveChanges();
            return old;
        }

        public Page Update(string stringKey, Action<Page> update)
        {
            Page old = _dbContext.Pages.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            if (old == null)
            {
                return null;
            }
            update(old);
            _dbContext.SaveChanges();
            return old;
        }
        public Page UpdatePage(Page model)
        {
            
                _dbContext.Pages.Update(model);
                _dbContext.SaveChanges();
                return model;
            
        }

        public Page Add(Page entity)
        {
            _dbContext.Pages.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
                Page entity = _dbContext.Pages.FirstOrDefault(_ => _.Id == id);
                if (entity == null)
                {
                    return false;
                }

                _dbContext.Pages.Remove(entity);
                _dbContext.SaveChanges();
                return true;
        }
    }
}