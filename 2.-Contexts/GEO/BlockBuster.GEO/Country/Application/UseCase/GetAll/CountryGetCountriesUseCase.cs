using BlockBuster.GEO.Country.Application.Converters;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.GEO.Country.Application.UseCase.GetAll
{
    public class CountryGetCountriesUseCase : UseCaseBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly CountryConverter _countryConverter;        
        
        public CountryGetCountriesUseCase(
            ICountryRepository countryRepository,
            CountryConverter countryConverter,
            IBlockBusterCountryContext context)
            : base(context)
        {
            _countryRepository = countryRepository;
            _countryConverter = countryConverter;
        }

        public override IResponse Execute(IRequest req)
        {
            CountryGetCountriesRequest request = req as CountryGetCountriesRequest;            

            var countryList = _countryRepository.GetAllCountries();

            return _countryConverter.Convert(countryList);
        }
        
    }
}
