using LinqKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Persistence.Repository
{
    public interface IRepositoryFilterBuilder<T>
    {
        ExpressionStarter<T> BuildFilter(IDictionary<string, string[]> filter);
    }

}
