using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub
{
    public class CountryCreatedAtStub
    {
        public static CountryCreatedAt Create(DateTime stamp)
        {
            return new CountryCreatedAt(stamp);
        }

        public static CountryCreatedAt ByDefault()
        {
            return Create(DateTime.Now);
        }
    }
}
