using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserEmailStub
    {
        public static UserEmail Create(string email)
        {
            return new UserEmail(email);
        }

        public static UserEmail ByDefault()
        {
            return Create("jonathan@mail.com");
        }
    }
}
