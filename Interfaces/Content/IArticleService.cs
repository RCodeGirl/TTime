using System;
using System.Collections.Generic;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface IArticleService
    {
        Article GetByKey(string stringKey);
        Article GetById(int id);
        Article GetByIdIncludeTags(int id);
        IList<Article> GetAll(bool onlyActive = true);
        //IList<Article> GetAllByCategoryKey(string stringKey, bool onlyActive = true);
        IList<Article> GetLast(int count, bool onlyActive = true);
        Article Update(Article entity);
        Article Add(Article entity);
        bool Delete(int id);
    }
}