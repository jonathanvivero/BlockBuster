using BlockBuster.Infrastructure.Persistence.Context;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Dummies
{
    public class DummyServiceProvider : IServiceProvider
    {
        object _service;

        public DummyServiceProvider(object service)
            => _service = service;
        
        public object GetService(Type serviceType)
            => _service;

        public object GetService<T>()
            => _service;        
    }
}
