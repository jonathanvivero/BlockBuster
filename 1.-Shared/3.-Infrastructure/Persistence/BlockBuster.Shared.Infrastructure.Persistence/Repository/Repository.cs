using BlockBuster.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BlockBuster.Shared.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IBlockBusterContext context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(IBlockBusterContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual TEntity GetById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual void Remove(Guid id)
        {
            dbSet.Remove(dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public int Count()
        {
            return dbSet.Count();
        }

        protected virtual void Dispose(bool cond)
        {
            //context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
