using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.IAM.Domain.UserAggregate.Exceptions
{
    public class UserFoundException : ValidationException
    {
        private UserFoundException(string message) : base(message)
        {

        }

        public static UserFoundException FromEmail(UserEmail userEmail)
        {
            return new UserFoundException(
                string.Format(
                    UserResources.ValidationUserEmailAlreadyExists, 
                    userEmail.GetValue()
                )
            );
        }

        public static UserFoundException FromCountry(string countryCode)
        {
            return new UserFoundException(
                string.Format(
                    UserResources.ValidationUserCountryDoesNotExist,
                    countryCode
                )
            );
        }
    }
}
