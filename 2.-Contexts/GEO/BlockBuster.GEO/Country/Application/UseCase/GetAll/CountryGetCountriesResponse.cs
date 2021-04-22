using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Application.UseCase.GetAll
{
    public class CountryGetCountriesResponse : IResponse
    {
        public IEnumerable<Domain.CountryAggregate.Country> Countries { get; private set; }

        public CountryGetCountriesResponse(IEnumerable<Domain.CountryAggregate.Country> countries)
        {
            Countries = countries;
        }
    }
}
