using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class BlockService : IBlockService
    {
        private readonly ApplicationDbContext _dbContext;

        public BlockService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Block> GetByBlockListKey(string stringKey, bool onlyActive = false)
        {
            var result = _dbContext.Blocks.Where(_ => _.BlockList.StringKey.Equals(stringKey));
            if (onlyActive)
            {
                result = result.Where(_ => !_.IsHidden);
            }
            return result.ToList();
        }

        public IList<Block> GetAll(bool onlyActive = false)
        {
            IQueryable<Block> result = _dbContext.Blocks.Include(_ => _.BlockList).OrderBy(_=>_.Pozition);
            if (onlyActive)
            {
                result = result.Where(_ => !_.IsHidden);
            }
            return result.ToList();
        }

        public Block GetByKey(string stringKey)
        {
            return _dbContext.Blocks.FirstOrDefault(_ => _.StringKey.Equals(stringKey));
        }

        public Block GetById(int id)
        {
            var result = _dbContext.Blocks.FirstOrDefault(_ => _.Id == id);
            return result;
        }

        public Block Update(Block entity)
        {
            _dbContext.Blocks.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Block Add(Block entity)
        {
            _dbContext.Blocks.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _dbContext.Blocks.FirstOrDefault(_ => _.Id == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Blocks.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public Block GetBlock(string stringKey)
        {
            return _dbContext.Blocks.FirstOrDefault(_ => _.StringKey.Equals(stringKey)) ;
        }

        public int GetPosition()
        {
            return _dbContext.Blocks.Max(_ => _.Pozition);
        }
    }
}