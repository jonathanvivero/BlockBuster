using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Persistence.Seed
{
    public interface ISeedChannel
    {
        void SeedDatabase();
    }
}
