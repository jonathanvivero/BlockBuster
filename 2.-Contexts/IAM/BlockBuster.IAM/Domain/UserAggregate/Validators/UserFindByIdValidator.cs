using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Validators
{
    public class UserFindByIdValidator
    {
        public UserFindByIdValidator()
        {

        }
        public void Validate(User user, UserId userId)
        {
            if (user == null)
                throw UserFoundException.FromFindById(userId.GetValue());
        }
    }

}
