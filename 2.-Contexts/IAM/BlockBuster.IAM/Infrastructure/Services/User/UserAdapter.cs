using BlockBuster.IAM.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserAdapter
    {
        private readonly UserFacade _userFacade;        

        public UserAdapter(UserFacade userFacade)
        {
            _userFacade = userFacade;            
        }

        public Country FindCountryFromCountryCode(string countryCode)
        {
            return _userFacade.FindCountryFromCountryCode(countryCode);
        }
    }
}
