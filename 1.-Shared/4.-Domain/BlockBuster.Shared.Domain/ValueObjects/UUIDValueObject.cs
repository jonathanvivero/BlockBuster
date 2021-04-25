using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Infrastructure.Resources;
using System.Text.RegularExpressions;

namespace BlockBuster.Shared.Domain.ValueObjects
{
    public class UUIDValueObject : StringValueObject
    {
        public UUIDValueObject(string value) : base(value)
        {
            if (string.IsNullOrEmpty(value))
                throw InvalidUUIDException.FromEmpty(DataTypeResources.UUID);

            if (!UUIDValueObject.Is(value))
                throw InvalidUUIDException.FromValue(DataTypeResources.UUID, value);
        }

        public static bool Is(string value)
        {
            Regex regex = new Regex(ValidationResources.UUIDV4PATTERN);
            Match match = regex.Match(value);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}
