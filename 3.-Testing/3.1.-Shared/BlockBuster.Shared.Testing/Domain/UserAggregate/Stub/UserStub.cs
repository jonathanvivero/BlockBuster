using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserStub
    {

        public static User ByDefault() 
        {
            return Create(
                UserIdStub.ByDefault(),
                UserEmailStub.ByDefault(),
                UserHashedPasswordStub.ByDefault(),
                UserFirstNameStub.ByDefault(),
                UserLastNameStub.ByDefault(),
                UserRoleStub.ByDefault(),
                UserCountryIdStub.ByDefault()
            );
        }


        private static User Create(UserId userId, 
            UserEmail userEmail, 
            UserHashedPassword userHashedPassword, 
            UserFirstName userFirstName, 
            UserLastName userLastName, 
            UserRole userRole, 
            UserCountryId userCountryId) 
        {
            return User.SignUp(
                userId,
                userEmail,
                userHashedPassword,
                userFirstName,
                userLastName,
                userRole,
                userCountryId);
        }
    }
}
