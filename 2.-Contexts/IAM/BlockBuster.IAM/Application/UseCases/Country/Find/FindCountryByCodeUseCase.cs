using BlockBuster.IAM.Application.Converters.Country;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.Country.Find
{
    public class FindCountryByCodeUseCase : IUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly CountryConverter _countryConverter;        
        public FindCountryByCodeUseCase(
            IUserRepository userRepository,
            CountryConverter countryConverter)
        {
            _userRepository = userRepository;
            _countryConverter = countryConverter;
        }

        public IResponse Execute(IRequest req)
        {
            FindCountryByCodeRequest request = req as FindCountryByCodeRequest;

            CountryCode countryCode = new CountryCode(request.Code);

            var country = _userRepository.FindCountryByCode(countryCode);                                    

            return _countryConverter.Convert(country);
        }
    }
}
