using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub
{
    public class CountryTaxStub
    {
        public static CountryTax Create(double tax)
        {
            return new CountryTax(tax);
        }

        public static CountryTax ByDefault()
        {
            return Create(10);
        }
    }
}
