using DomainModel.Content;
using System;
using System.Collections.Generic;


namespace Interfaces.Content
{
     public interface ISaleService
    {
        List<Sale> GetAll();


        bool Delete(int id);
        Sale Create(Sale entity);



        Sale Edite(Sale entity);

        Sale GetByKey(string stringKey);
        Sale GetById(int id);
    }
}
