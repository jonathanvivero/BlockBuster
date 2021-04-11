using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserPassword : StringValueObject
    {
        

        public UserPassword(string value) : base(value)
        {
            if (!this.Is(value))
                throw InvalidUserAttributeException.FromValue(UserResources.Password, value);
        }

        private bool Is(string value)
        {
            Regex regex = new Regex(UserResources.PasswordPattern);
            Match match = regex.Match(value);

            if (match.Success)
                return true;

            return false;
        }

        public static void Validate(string password, string repeatPassword)
        {
            if (password != repeatPassword)
                throw InvalidUserAttributeException.FromText(
                    UserResources.ValidationPasswordShouldMatchRepeatPassword
                );
        }
    }
}
