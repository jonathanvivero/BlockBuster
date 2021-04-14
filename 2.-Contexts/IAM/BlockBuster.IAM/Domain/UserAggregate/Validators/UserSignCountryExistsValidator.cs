using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Validators
{
    public class UserSignUpCountryExistsValidator
    {        
        public UserSignUpCountryExistsValidator()
        {            
        }

        public void Validate(object country, string coutryCode)
        {            
            if (country == null)
            {
                throw UserFoundException.FromCountry(coutryCode);
            }
        }
    }
}
