using BlockBuster.Shared.Domain.Exceptions;

namespace BlockBuster.IAM.Domain.UserAggregate.Exceptions
{
    public class InvalidUserAttributeException : InvalidAttributeException
    {
        private InvalidUserAttributeException(string message) : base(message)
        {

        }
    }
}
