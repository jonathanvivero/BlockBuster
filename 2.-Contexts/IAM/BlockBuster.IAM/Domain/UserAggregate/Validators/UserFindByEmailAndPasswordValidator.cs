using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Validators
{
    public class UserFindByEmailAndPasswordValidator
    {
        public UserFindByEmailAndPasswordValidator()
        {

        }
        public void Validate(User user)
        {
            if (user == null)
                throw UserFoundException.FromFindByEmailAndPassword();
        }
    }

}
