using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Validators
{
    public class UserSignUpValidator
    {
        private IUserRepository userRepository;

        public UserSignUpValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void ValidateExistingUser(UserEmail userEmail)
        {
            var user = this.userRepository.FindUserByEmail(userEmail);

            if (user != null)
            {
                throw UserFoundException.FromEmail(userEmail);
            }
        }

        public void ValidateCountryExists(Country country, string countryCode)
        {            
            if (country == null)
            { 
                throw UserFoundException.FromCountry(countryCode);
            }
        }
    }
}
