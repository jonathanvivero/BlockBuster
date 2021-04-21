using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Dummies
{
    class DummyServiceScope : IServiceScope
    {
        private readonly object _service;
        public DummyServiceScope(object service)
            => _service = service;

        public IServiceProvider ServiceProvider 
            => new DummyServiceProvider(_service);

        public void Dispose()
        {
            
        }
    }
}
