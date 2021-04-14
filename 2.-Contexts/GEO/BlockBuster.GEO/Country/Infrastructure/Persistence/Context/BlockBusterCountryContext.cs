using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.GEO.Country.Infrastructure.Persistence.Seed;
using BlockBuster.GEO.Country.Infrastructure.Presistence.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlockBuster.Infrastructure.Persistence.Context
{
    public class BlockBusterCountryContext :                        
            BlockBusterContext<IBlockBusterCountryContext>,
            IBlockBusterCountryContext
    {
        private readonly IServiceProvider _serviceProvider;
        public BlockBusterCountryContext(DbContextOptions options, 
            IServiceProvider serviceProvider) 
            : base(options) 
        {
            _serviceProvider = serviceProvider;
        }

        public DbSet<Country> Countries { get; set; }

        protected override void SetEntityModelMapping(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfiguration(new CountryMap());
        }

        protected override void SetUpDatabaseSeeding() 
        {            
            _seedList.Add(_serviceProvider.GetService<SeedCountries>());
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
