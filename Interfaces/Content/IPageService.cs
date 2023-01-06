using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface IPageService
    {
        IList<Page> GetPageByKey(string stringKey);
        Page GetByKey(string stringKey);

        Page GetById(int id);

        List<Page> GetAll();

        List<TResult> GetAll<TResult>(Expression<Func<Page, TResult>> selector);

        Page Update(int id, Action<Page> update);

        Page Update(string stringKey, Action<Page> update);

        Page UpdatePage(Page page);

        Page Add(Page entity);

        bool Delete(int id);
    }
}