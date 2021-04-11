using BlockBuster.IAM.Application.UseCases.Country.Find;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.Shared.Application.Bus.UseCase;


namespace BlockBuster.IAM.Application.Converters.Country
{
    public class CountryConverter
    {
        private readonly ICountryFactory _countryFactory;
        public CountryConverter(ICountryFactory countryFactory)
        {
            _countryFactory = countryFactory;
        }

        public Domain.UserAggregate.Country FromResponse(IResponse resp)
        {
            FindCountryByCodeResponse response = resp as FindCountryByCodeResponse;

            var country = _countryFactory
                .Create(
                    response.Id,
                    response.Code, 
                    response.Tax, 
                    response.CreatedAt, 
                    response.UpdatedAt
                );

            return country;
        }

        public IResponse Convert(Domain.UserAggregate.Country country)
        {
            var response = new FindCountryByCodeResponse(
                country.Id, 
                country.Code, 
                country.Tax, 
                country.CreatedAt, 
                country.UpdatedAt);

            return response;
        }
    }
}
