using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Validators
{
    public class UserSignUpEmailDoesNotExistValidator
    {
        private IUserRepository userRepository;

        public UserSignUpEmailDoesNotExistValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Validate(string email)
        {
            var userEmail = new UserEmail(email);
            var user = this.userRepository.FindUserByEmail(userEmail);

            if (user != null)
            {
                throw UserFoundException.FromEmail(userEmail);
            }
        }
    }
}
