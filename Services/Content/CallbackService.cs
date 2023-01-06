using System.Collections.Generic;
using System.Linq;
using DomainModel.Content;
using Interfaces.Content;

namespace Services.Content
{
    public class CallbackService : ICallbackService
    {
        private readonly ApplicationDbContext _dbContext;

        public CallbackService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Callback Add(Callback entity)
        {
            _dbContext.Callbacks.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public Callback Hide(int id)
        {
            var callback = _dbContext.Callbacks.FirstOrDefault(_ => _.Id == id);
            if (callback == null) return null;

            callback.IsNew = false;
            _dbContext.SaveChanges();

            return callback;
        }

        public IList<Callback> Get(bool onlyNew = false)
        {
            IQueryable<Callback> result = _dbContext.Callbacks;
            if (onlyNew)
            {
                result = result.Where(_ => _.IsNew);
            }

            return result.ToList();
        }
    }
}