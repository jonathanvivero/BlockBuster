using System;
using System.Linq;

namespace BlockBuster.Shared.Infrastructure.Persistence
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(string id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(Guid id);
        int Count();
        int SaveChanges();
    }
}