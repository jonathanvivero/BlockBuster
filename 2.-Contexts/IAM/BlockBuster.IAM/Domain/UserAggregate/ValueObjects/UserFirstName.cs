using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.ValueObjects
{
    public class UserFirstName : StringValueObject
    {
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 15;
        public UserFirstName(string value) : base(value)
        {
            if (value.Length < MIN_LENGTH)
                throw InvalidUserAttributeException.FromMinLength(UserResources.FieldFirstName, MIN_LENGTH);

            if (value.Length > MAX_LENGTH)
                throw InvalidUserAttributeException.FromMaxLength(UserResources.FieldFirstName, MAX_LENGTH);
        }
    }
}
