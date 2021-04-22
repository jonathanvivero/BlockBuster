using BlockBuster.GEO.Country.Domain.CountryAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub
{
    public class CountryIdStub
    {
        public static CountryId Create(string id)
        {
            return new CountryId(id);
        }

        public static CountryId ByDefault()
        {
            return Create("d5a29699-eff3-448c-986a-10e06a1753b4");
        }
    }
}
