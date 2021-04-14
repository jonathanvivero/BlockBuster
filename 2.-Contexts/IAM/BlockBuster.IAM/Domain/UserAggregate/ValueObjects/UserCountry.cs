using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;
using System.Collections.Generic;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserCountry : ValueObject<Country>
    {
        private const int CODE_LENGTH = 3;        
        public UserCountry(Country value): base(value)
        {                        

            if (value == null)
                throw InvalidUserAttributeException
                    .FromMinLength(UserResources.FieldCountry, CODE_LENGTH);            
        }       
    }
}
