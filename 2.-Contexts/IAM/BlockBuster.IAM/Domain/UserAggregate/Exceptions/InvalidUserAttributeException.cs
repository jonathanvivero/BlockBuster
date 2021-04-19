using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.Exceptions;

namespace BlockBuster.IAM.Domain.UserAggregate.Exceptions
{
    public class InvalidUserAttributeException : InvalidAttributeException
    {
        private InvalidUserAttributeException(string message) : base(message)
        {

        }

        public static InvalidUserAttributeException FromMisMatchingPasswords()
        {
            return new InvalidUserAttributeException(UserResources.ValidationPasswordShouldMatchRepeatPassword);
        }

    }
}
