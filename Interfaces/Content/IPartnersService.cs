using System;
using System.Collections.Generic;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface IPartnersService
    {
        Partner GetById(int id);

        List<Partner> GetAll();
        Partner Add(Partner client);
        Partner Update(Partner client);
        bool Delete(int id);
    }
}
