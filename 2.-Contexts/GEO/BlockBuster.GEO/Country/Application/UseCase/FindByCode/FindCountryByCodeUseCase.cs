using BlockBuster.GEO.Country.Application.Converters;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryByCodeUseCase : UseCaseBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly CountryConverter _countryConverter;        
        
        public FindCountryByCodeUseCase(
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
            FindCountryByCodeRequest request = req as FindCountryByCodeRequest;

            CountryCode countryCode = new CountryCode(request.Code);

            var countryId = _countryRepository.FindByCode(countryCode);                                    

            return _countryConverter.Convert(countryId);
        }
        
    }
}
