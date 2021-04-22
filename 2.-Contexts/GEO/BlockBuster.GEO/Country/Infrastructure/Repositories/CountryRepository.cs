using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlockBuster.GEO.Country.Infrastructure.Repositories
{
    public class CountryRepository : Repository<Domain.CountryAggregate.Country>, ICountryRepository
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public CountryRepository(IBlockBusterCountryContext context,
            IServiceScopeFactory serviceScopeFactory)
            : base(context)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        public Domain.CountryAggregate.Country FindByCode(CountryCode countryCode)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterCountryContext>();
                return dbContext
                    .Countries
                    .FirstOrDefault(w => w.Code.GetValue() == countryCode.GetValue());
            }
        }
        public Domain.CountryAggregate.Country FindById(CountryId countryId)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterCountryContext>();
                return dbContext
                    .Countries
                    .FirstOrDefault(w => w.Id.GetValue() == countryId.GetValue());
            }
        }

    }
}
