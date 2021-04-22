using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Application.UseCase.GetAll;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using System.Collections.Generic;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserFacade: IUserFacade
    {
        private readonly IUseCaseBus _useCaseBus;
        private readonly IUserTranslator _userTranslator;

        public UserFacade(IUseCaseBus useCaseBus, 
            IUserTranslator userTranslator)
        {
            _useCaseBus = useCaseBus;
            _userTranslator = userTranslator;
        }

        public UserCountry FindCountryFromCountryCode(string countryCode)
        {
            var request = new FindCountryByCodeRequest(countryCode);
            IResponse response = _useCaseBus.Dispatch(request);
            return _userTranslator.FromFindCountryByCodeResponseToUserCountry(response);
        }

        public UserCountry FindCountryFromCountryId(string countryId)
        {
            var request = new FindCountryByIdRequest(countryId);
            IResponse response = _useCaseBus.Dispatch(request);
            return _userTranslator.FromFindCountryByCodeResponseToUserCountry(response);
        }


        public IEnumerable<UserCountry> GetCountries()
        {
            var request = new CountryGetCountriesRequest();
            IResponse response = _useCaseBus.Dispatch(request);
            return _userTranslator.FromCountryListToUserCountryList(response);
        }
    }
}
