using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Exceptions
{
    public class UserUpdate204NoContentToBeUpdated : ContentException
    {
        public UserUpdate204NoContentToBeUpdated(string message)
            : base(message)
        {
        }
        public static UserUpdate204NoContentToBeUpdated FromNoContentToBeUpdated()
        {
            return new UserUpdate204NoContentToBeUpdated(
                UserResources.ValidationPartialUpdateNoContentToBeUpdated
            );
        }
    }
}
