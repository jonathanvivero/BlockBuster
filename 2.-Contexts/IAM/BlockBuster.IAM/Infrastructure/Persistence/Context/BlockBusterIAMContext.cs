using BlockBuster.IAM.Domain.TokenAggregate;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Infrastructure.Persistence.Seed;
using BlockBuster.IAM.Infrastructure.Presistence.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlockBuster.Infrastructure.Persistence.Context
{
    public class BlockBusterIAMContext :                        
            BlockBusterContext<IBlockBusterIAMContext>,
            IBlockBusterIAMContext
    {
        private readonly IServiceProvider _serviceProvider;
        public BlockBusterIAMContext(DbContextOptions options, 
            IServiceProvider serviceProvider) 
            : base(options) 
        {
            _serviceProvider = serviceProvider;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void SetEntityModelMapping(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TokenMap());
        }

        protected override void SetUpDatabaseSeeding() 
        {            
            _seedList.Add(_serviceProvider.GetService<SeedUsers>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        protected virtual void Dispose(bool cond)
        {
            //context.Dispose();
            GC.SuppressFinalize(this);
        }

        public new void Dispose()
        {
            this.Dispose(true);
        }        
    }
}
