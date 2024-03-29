﻿

using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Application.UseCase.GetAll;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockBuster.GEO.Country.Application.Converters
{
    public class CountryConverter
    {        
        public CountryConverter()
        {            
        }
        
        public IResponse Convert(Domain.CountryAggregate.Country country)
        {
            var response = new FindCountryByCodeResponse(country);

            return response;
        }
        public IResponse Convert(IEnumerable<Domain.CountryAggregate.Country> countries)
        {
            var response = new CountryGetCountriesResponse(countries);

            return response;
        }
    }
}
