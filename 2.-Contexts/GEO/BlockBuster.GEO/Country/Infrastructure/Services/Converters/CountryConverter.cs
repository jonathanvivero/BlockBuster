

using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.GEO.Country.Application.Converters
{
    public class CountryConverter
    {        
        public CountryConverter()
        {            
        }
        
        public IResponse Convert(CountryId countryId)
        {
            var response = new FindCountryByCodeResponse(countryId);

            return response;
        }
    }
}
