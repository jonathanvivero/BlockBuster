using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub
{
    public class CountryCodeStub
    {
        public static CountryCode Create(string code)
        {
            return new CountryCode(code);
        }

        public static CountryCode ByDefault()
        {
            return Create("ESP");
        }


    }
}
