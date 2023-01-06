using System.Collections.Generic;
using DomainModel.Content;

namespace Interfaces.Content
{
    public interface ICallbackService
    {
        IList<Callback> Get(bool onlyNew = false);

        Callback Add(Callback entity);

        Callback Hide(int id);
    }
}