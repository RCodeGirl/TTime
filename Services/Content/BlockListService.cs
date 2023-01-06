using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainModel.Content;
using Interfaces.Content;
using Microsoft.EntityFrameworkCore;

namespace Services.Content
{
    public class BlockListService : IBlockListService
    {
        private readonly ApplicationDbContext _dbContext;

        public BlockListService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BlockList Add(BlockList entity)
        {
            _dbContext.BlockLists.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int? Id)
        {
            BlockList entity = _dbContext.BlockLists.FirstOrDefault(_ => _.Id == Id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.BlockLists.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public BlockList Edite(BlockList entity)
        {
            _dbContext.BlockLists.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public IList<BlockList> GetAll()
        {
            IQueryable<BlockList> result = _dbContext.BlockLists.Include(_ => _.Blocks).OrderBy(_=>_.Pozition);
            return result.ToList();
        }

        public IList<TResult> GetAll<TResult>(Expression<Func<BlockList, TResult>> selector)
        {
            IQueryable<TResult> result = _dbContext.BlockLists.Include(_ => _.Blocks).Select(selector);
            return result.ToList();
        }

        public BlockList GetById(int Id)
        {
            BlockList result = _dbContext.BlockLists.FirstOrDefault(_ => _.Id == Id);
            return result;
        }

        public int GetPosition()
        {
            return _dbContext.BlockLists.Max(_ => _.Pozition);
        }
    }
}