using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Dummies
{
    public class DummyServiceScopeFactory : IServiceScopeFactory
    {
        private readonly object _service;
        public DummyServiceScopeFactory(object service)
         => _service  = service;

        public IServiceScope CreateScope() 
            => new DummyServiceScope(_service);
    }
}
