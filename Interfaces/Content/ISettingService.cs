using System;
using System.Collections.Generic;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface ISettingService
    {
        Setting GetByKey(string stringKey);

        Setting GetById(int id);

        IList<Setting> GetAll();

        Setting Update(int id, Action<Setting> update);

        Setting Update(string stringKey, Action<Setting> update);

        Setting Add(Setting entity);

        bool Delete(int id);
    }
}