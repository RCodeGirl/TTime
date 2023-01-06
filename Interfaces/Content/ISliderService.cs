using System;
using System.Collections.Generic;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface ISliderService
    {
        Slider GetById(int? id);

        IList<Slider> GetAll(bool onlyActive = false);

        Slider Update(Slider entity);

        Slider Add(Slider entity);

        bool Delete(int id);
    }
}