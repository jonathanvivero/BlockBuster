using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class PayloadStub
    {
        public static IDictionary<string, string> Create(User user)
        {
            return new Dictionary<string, string>()
            {
                [TokenResources.PayloadUsedId] = user.Id.GetValue(),
                [TokenResources.PayloadRole] = user.Role.GetValue(),
                [TokenResources.PayloadCountryCode] = user.Country.GetValue().Code.GetValue(),
                [TokenResources.PayloadCountryId] = user.Country.GetValue().Id.GetValue(),
                [TokenResources.PayloadEmail] = user.Email.GetValue(),
                [TokenResources.PayloadFirstName] = user.FirstName.GetValue(),
                [TokenResources.PayloadLastName] = user.LastName.GetValue()
            };
        }
        public static IDictionary<string, string> ByDefault()
        {
            return Create(UserStub.ByDefault());
        }
    }
}
