using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System.Collections.Generic;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserAdapter: IUserAdapter
    {
        private readonly IUserFacade _userFacade;        

        public UserAdapter(IUserFacade userFacade)
        {
            _userFacade = userFacade;            
        }

        public UserCountry FindCountryFromCountryCode(string countryCode)
        {
            return _userFacade.FindCountryFromCountryCode(countryCode);
        }

        public UserCountry FindCountryFromCountryId(string countryId)
        {
            return _userFacade.FindCountryFromCountryId(countryId);
        }
        public IEnumerable<UserCountry> GetUserCountries()
        {
            return _userFacade.GetCountries();
        }
    }


}
