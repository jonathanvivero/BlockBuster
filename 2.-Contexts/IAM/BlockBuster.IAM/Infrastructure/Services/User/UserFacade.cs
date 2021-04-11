using BlockBuster.IAM.Application.Converters.Country;
using BlockBuster.IAM.Application.UseCases.Country.Find;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserFacade
    {
        private readonly IUseCaseBus _useCaseBus;
        private readonly CountryConverter _countryConverter;
        private readonly IBlockBusterIAMContext _context;

        public UserFacade(IUseCaseBus useCaseBus,
            CountryConverter countryConverter, 
            IBlockBusterIAMContext context)
        {
            _useCaseBus = useCaseBus;
            _countryConverter = countryConverter;
            _context = context;
        }

        public Country FindCountryFromCountryCode(string countryCode)
        {
            FindCountryByCodeRequest request = new FindCountryByCodeRequest(countryCode);
            IResponse response = _useCaseBus.Dispatch(request, _context);
            Country country = _countryConverter.FromResponse(response);
            return country;
        }
    }
}
