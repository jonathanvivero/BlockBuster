using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Validators
{
    public class UserPartialUpdateUserValidator
    {
        public void ValidateUserIsAuthorized(string currentUserId, string userToBeUpdatedId)
        {
            if (currentUserId != userToBeUpdatedId)
                throw UserPartialUpdateAuthorizationException.FromUserNotAuthorizedOnUpdate();
        }

        public void ValidateContentNotEmpty(string firstName, string lastName, string password)
        {
            if (string.IsNullOrEmpty(firstName)
                && string.IsNullOrEmpty(lastName)
                && string.IsNullOrEmpty(password))
                throw UserUpdate204NoContentToBeUpdated.FromNoContentToBeUpdated();
        }
    }
}
