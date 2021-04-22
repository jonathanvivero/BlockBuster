using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryByCodeResponse : IResponse
    {
        public Domain.CountryAggregate.Country Country { get; private set; }
        public FindCountryByCodeResponse(Domain.CountryAggregate.Country country)
        {
            this.Country = country;
        }
    }
}
