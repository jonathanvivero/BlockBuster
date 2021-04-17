using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserAdapter
    {
        private readonly UserFacade _userFacade;        

        public UserAdapter(UserFacade userFacade)
        {
            _userFacade = userFacade;            
        }

        public UserCountryId FindCountryFromCountryCode(string countryCode)
        {
            return _userFacade.FindCountryFromCountryCode(countryCode);
        }

       
    }
}
