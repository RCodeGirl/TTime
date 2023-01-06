using System;
using System.Collections.Generic;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface IBlockService
    {
        IList<Block> GetByBlockListKey(string stringKey, bool onlyActive = false);

        IList<Block> GetAll(bool onlyActive = false);

        Block GetByKey(string stringKey);

        Block GetById(int id);

        Block Update(Block entity);

        Block Add(Block entity);

        public int GetPosition();

        bool Delete(int id);
    }
}