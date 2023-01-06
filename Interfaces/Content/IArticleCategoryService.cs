using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface IArticleCategoryService
    {
        ArticleCategory GetByKey(string stringKey);

        ArticleCategory GetById(int id);

        IList<ArticleCategory> GetAll();

        IList<TResult> GetAll<TResult>(Expression<Func<ArticleCategory, TResult>> selector);

        ArticleCategory Update(int id, Action<ArticleCategory> update);

        ArticleCategory Add(ArticleCategory entity);

        bool Delete(int id);
    }
}