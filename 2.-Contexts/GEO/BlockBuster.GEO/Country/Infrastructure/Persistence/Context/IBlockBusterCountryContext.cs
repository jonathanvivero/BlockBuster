using BlockBuster.GEO.Country.Domain.CountryAggregate;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.Infrastructure.Persistence.Context
{
    public interface IBlockBusterCountryContext: IBlockBusterContext
    {
        DbSet<Country> Countries { get; set; }

    }
}
