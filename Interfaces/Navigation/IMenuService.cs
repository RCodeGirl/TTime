using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DomainModel.Navigation;

namespace Interfaces.Navigation
{
    public interface IMenuService
    {
        List<Menu> GetAll();

        IList<TResult> GetAll<TResult>(Expression<Func<Menu, TResult>> selector);

        bool Delete(int id);
        Menu Create (Menu entity);

       

        Menu Edite(Menu entity);

        Menu GetByKey(string stringKey);
        Menu GetById(int id);
        


    }
}