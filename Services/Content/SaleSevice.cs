using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Content;
using System.Threading.Tasks;
using DomainModel.Content;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class SaleSevice : ISaleService
    {
        private readonly ApplicationDbContext _dbContext;
        public SaleSevice(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Sale Create(Sale entity)
        {
            _dbContext.Sales.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _dbContext.Sales.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Sales.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public Sale Edite(Sale entity)
        {
            _dbContext.Sales.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public List<Sale> GetAll()
        {
            DbSet<Sale> result = _dbContext.Sales;
            return result.ToList();
        }

       

        public Sale GetById(int id)
        {
            var result = _dbContext.Sales.FirstOrDefault(_ => _.Id.Equals(id));
            return result;
        }

        public Sale GetByKey(string stringKey)
        {
            var result = _dbContext.Sales.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
            return result;

        }
    }
}
