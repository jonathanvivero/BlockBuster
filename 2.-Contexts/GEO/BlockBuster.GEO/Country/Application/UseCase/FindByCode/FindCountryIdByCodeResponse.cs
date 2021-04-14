using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryIdByCodeResponse : IResponse
    {
        public string Id { get; }        
        public FindCountryIdByCodeResponse(CountryId id)
        {            
            this.Id = id.GetValue();         
        }
    }
}
