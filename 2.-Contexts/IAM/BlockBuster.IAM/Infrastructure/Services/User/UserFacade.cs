using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserFacade
    {
        private readonly IUseCaseBus _useCaseBus;
        private readonly UserTranslator _userTranslator;

        public UserFacade(IUseCaseBus useCaseBus, 
            UserTranslator userTranslator)
        {
            _useCaseBus = useCaseBus;
            _userTranslator = userTranslator;
        }

        public UserCountryId FindCountryFromCountryCode(string countryCode)
        {
            var request = new FindCountryIdByCodeRequest(countryCode);
            IResponse response = _useCaseBus.Dispatch(request);
            return _userTranslator.FromFindCountryIdByCodeResponseToUserCountryId(response);
        }
    }
}
