using BlockBuster.Shared.Infrastructure.Persistence.Context.Extensions;
using BlockBuster.Shared.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace BlockBuster.Infrastructure.Persistence.Context
{
    public abstract class BlockBusterContext<TContext>: 
        DbContext,
        IBlockBusterContext        
        where TContext: IBlockBusterContext
    {
        protected IList<SeedChannel<TContext>> _seedList;
        public BlockBusterContext(DbContextOptions options) : base(options) 
        {
            _seedList = new List<SeedChannel<TContext>>();
        }

        public new DatabaseFacade Database
            => base.Database;

        public new void SaveChanges()
            => base.SaveChanges();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetEntityModelMapping(modelBuilder);
            SetUpDatabaseSeeding();

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Seed(_seedList.ToArray());

            _seedList.Clear();
            _seedList = null;
        }

        protected abstract void SetEntityModelMapping(ModelBuilder modelBuilder);
        protected abstract void SetUpDatabaseSeeding();

    }
}
