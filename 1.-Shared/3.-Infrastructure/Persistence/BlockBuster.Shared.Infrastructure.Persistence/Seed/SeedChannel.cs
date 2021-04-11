using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Persistence.Seed
{
    public abstract class SeedChannel<TContext>: ISeedChannel
    {
        protected readonly TContext _context;        

        public SeedChannel(TContext context)
        {
            _context = context;
        }

        public abstract void SeedDatabase();
    }
}
