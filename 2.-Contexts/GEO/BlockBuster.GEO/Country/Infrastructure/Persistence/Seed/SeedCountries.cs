using BlockBuster.Shared.Infrastructure.Persistence.Seed;
using System;
using System.Linq;
using System.Collections.Generic;
using BlockBuster.GEO.Country.Infrastructure.Services.Factories;
using BlockBuster.Infrastructure.Persistence.Context;

namespace BlockBuster.GEO.Country.Infrastructure.Persistence.Seed
{
    public class SeedCountries : SeedChannel<IBlockBusterCountryContext>
    {
        private CountryFactory _countryFactory;
        public SeedCountries(IBlockBusterCountryContext context,
            CountryFactory countryFactory)
            : base(context)
        {
            _countryFactory = countryFactory;
        }

        public override void SeedDatabase()
        {
            if (!_context.Countries.Any())
            {
                var countries = ListOfCountries();                

                _context.Countries.AddRange(countries);
                _context.SaveChanges();
            }

        }

        private IList<Domain.CountryAggregate.Country> ListOfCountries()
        {
            return new List<Domain.CountryAggregate.Country>()
            {
                _countryFactory.Create(
                    "d5a29699-eff3-448c-986a-10e06a1753b4",
                    "ESP",
                    21,
                    DateTime.Now,
                    DateTime.Now),
                _countryFactory.Create(
                    "d5a29699-eff3-448c-986a-10e06a1753b4",
                    "FRA",
                    8,
                    DateTime.Now,
                    DateTime.Now),
                _countryFactory.Create(
                    "d5a29699-eff3-448c-986a-10e06a1753b4",
                    "POR",
                    20,
                    DateTime.Now,
                    DateTime.Now),
                _countryFactory.Create(
                    "d5a29699-eff3-448c-986a-10e06a1753b4",
                    "USA",
                    10,
                    DateTime.Now,
                    DateTime.Now),
                _countryFactory.Create(
                    "d5a29699-eff3-448c-986a-10e06a1753b4",
                    "GBR",
                    25,
                    DateTime.Now,
                    DateTime.Now)
            };
        }
    }
}
