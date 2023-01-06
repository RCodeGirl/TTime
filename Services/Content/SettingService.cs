using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class SettingService : ISettingService
    {
        private readonly ApplicationDbContext _dbContext;

        public SettingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Setting GetByKey(string stringKey)
        {
            Setting result = _dbContext.Settings.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            return result;
        }

        public Setting GetById(int id)
        {
            Setting result = _dbContext.Settings.FirstOrDefault(_ => _.Id == id);
            return result;
        }

        public IList<Setting> GetAll()
        {
            DbSet<Setting> result = _dbContext.Settings;
            return result.ToList();
        }

        public Setting Update(int id, Action<Setting> update)
        {
            Setting old = _dbContext.Settings.FirstOrDefault(_ => _.Id == id);
            if (old == null)
            {
                return null;
            }
            update(old);
            _dbContext.SaveChanges();
            return old;
        }

        public Setting Update(string stringKey, Action<Setting> update)
        {
            Setting old = _dbContext.Settings.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            if (old == null)
            {
                return null;
            }
            update(old);
            _dbContext.SaveChanges();
            return old;
        }

        public Setting Add(Setting entity)
        {
            _dbContext.Settings.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Setting entity = _dbContext.Settings.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Settings.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}