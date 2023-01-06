using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using Interfaces.Content;

namespace Services.Content
{
    public class PartnersService : IPartnersService
    {
        private readonly ApplicationDbContext _dbContext;

        public PartnersService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Partner GetById(int id)
        {
            var result = _dbContext.Partners.FirstOrDefault(_ => _.Id == id);
            return result;
        }
        public List<Partner> GetAll()
        {
            var result = _dbContext.Partners;
            return result.ToList();
        }
        public Partner Add(Partner entity)
        {
            _dbContext.Partners.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public Partner Update(Partner entity)
        {
            _dbContext.Partners.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public bool Delete(int id)
        {
            Partner entity = _dbContext.Partners.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Partners.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
