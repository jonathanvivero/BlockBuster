using BlockBuster.IAM.Application.UseCases.User.SignUp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class CountryDTOStub
    {
        public static CountryDTO Create(string countryCode)
        {
            return new CountryDTO(countryCode);
        }
        public static CountryDTO ByDefault()
        {
            return Create("ESP");
        }        

    }
}
