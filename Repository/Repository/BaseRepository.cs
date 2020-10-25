using Domain.IRepository;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApiContext ApiContext;

        public BaseRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        public void Incluid(TEntity entity)
        {
            ApiContext.Set<TEntity>().Add(entity);
            ApiContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            ApiContext.Set<TEntity>().Update(entity);
            ApiContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            ApiContext.Remove(entity);
            ApiContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ApiContext.Set<TEntity>().ToList();
        }

        public TEntity GetbyId(long Id)
        {
            return ApiContext.Set<TEntity>().Find(Id);
        }

        public void Dispose()
        {
            ApiContext.Dispose();
        }
    }
}
