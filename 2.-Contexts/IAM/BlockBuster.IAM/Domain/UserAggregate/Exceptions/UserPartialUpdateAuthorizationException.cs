using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.IAM.Domain.UserAggregate.Exceptions
{
    public class UserPartialUpdateAuthorizationException : AuthorizationException
    {
        private UserPartialUpdateAuthorizationException(string message) : base(message)
        {

        }

        public static UserPartialUpdateAuthorizationException FromUserNotAuthorizedOnUpdate()
        {
            return new UserPartialUpdateAuthorizationException(
                UserResources.ValidationPartialUpdateUserNotAuthorized
            );
        }

       

    }
}
