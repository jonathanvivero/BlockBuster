using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub
{
    public class CountryUpdatedAtStub
    {
        public static CountryUpdatedAt Create(DateTime stamp)
        {
            return new CountryUpdatedAt(stamp);
        }

        public static CountryUpdatedAt ByDefault()
        {
            return Create(DateTime.Now);
        }
    }
}
