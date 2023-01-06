using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface IBlockListService
    {
        IList<BlockList> GetAll();

        BlockList GetById(int Id);

        IList<TResult> GetAll<TResult>(Expression<Func<BlockList, TResult>> selector);

        BlockList Add(BlockList entity);

        bool Delete(int? Id);

        BlockList Edite(BlockList entity);

       int GetPosition();


    }
}