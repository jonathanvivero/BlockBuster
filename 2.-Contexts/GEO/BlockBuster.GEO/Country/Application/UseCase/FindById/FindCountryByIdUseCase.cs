using BlockBuster.GEO.Country.Application.Converters;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryByIdUseCase : UseCaseBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly CountryConverter _countryConverter;        
        
        public FindCountryByIdUseCase(
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
            FindCountryByIdRequest request = req as FindCountryByIdRequest;

            CountryId countryId = new CountryId(request.Id);

            var country = _countryRepository.FindById(countryId);                                    

            return _countryConverter.Convert(country);
        }
        
    }
}
