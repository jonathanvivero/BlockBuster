using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.Shared.Domain.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserCountry : ValueObject<Country>
    {
        public UserCountry(Country value): base(value)
        {
            if (value == null)
                throw InvalidUserAttributeException
                    .FromNullCountry();                          
        }       
    }
}
