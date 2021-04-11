using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Infrastructure.Persistence.Context
{
    public interface IBlockBusterContext
    {
        DatabaseFacade Database { get; }
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
