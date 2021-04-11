using BlockBuster.Shared.Infrastructure.Resources;
using BlockBuster.Shared.Infrastructure.Extensions;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class InvalidAttributeException : ValidationException
    {
        public InvalidAttributeException(string message) : base(message)
        {
        }

        public static InvalidAttributeException FromText(string text)
        {
            return new InvalidAttributeException(text);
        }

        public static InvalidAttributeException FromEmpty(string attribute)
        {
            return new InvalidAttributeException(
                ValidationResources.InvalidAttributeExceptionFromEmpty.Format(attribute)
            );
        }

        public static InvalidAttributeException FromValue(string attribute, string value)
        {
            return new InvalidAttributeException(
                ValidationResources.InvalidAttributeExceptionFromValue.Format(attribute, value)
            );
        }

        public static InvalidAttributeException FromMaxLength(string attribute, int length)
        {
            return new InvalidAttributeException(
                ValidationResources.InvalidAttributeExceptionFromMaxLength.Format(attribute, length)
            );
        }

        public static InvalidAttributeException FromMinLength(string attribute, int length)
        {
            return new InvalidAttributeException(
                ValidationResources.InvalidAttributeExceptionFromMinLength.Format(attribute, length)
            );
        }

        public static InvalidAttributeException FromLength(string attribute, int length)
        {
            return new InvalidAttributeException(
                ValidationResources.InvalidAttributeExceptionFromLength.Format(attribute, length)
            );
        }
    }

}
