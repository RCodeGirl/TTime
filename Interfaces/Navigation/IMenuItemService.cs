using System;
using System.Collections.Generic;
using DomainModel.Navigation;

namespace Interfaces.Navigation
{
    public interface IMenuItemService
    {
        IList<MenuItem> GetByMenuKey(string stringKey, bool onlyActive = true);

        IList<MenuItem> GetAll(bool onlyActive = false);

        MenuItem GetById(int id);
        IList<MenuItem> GetByKey(string Key);
        IList<MenuItem> GetByParentId(int ParentId);
        IList<MenuItem> GetByParentId(int? Id);

        MenuItem Update(MenuItem entity);

        MenuItem Add(MenuItem entity);

        bool Delete(int id);

        public int GetPosition();
    }
}