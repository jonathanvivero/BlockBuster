using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events
{
    public abstract class DomainEventBody
    {
        protected string _domainEventName;
        protected IDictionary<string, string> _body;
        public int Count { get; private set; }
        public DomainEventBody()
        {
            _body = new Dictionary<string, string>();
        }

        public DomainEventBody SetDomainName(string name)
        { 
            _domainEventName = name;
            return this;
        }
        
        protected void Add<T>(string rule, ValueObject<T> type)
        {
            _body.Add(rule, type.GetValue().ToString());
            Count = _body.Count;
        }

        public IEnumerable<string> Keys()
            => _body.Keys;

        public bool Has(string key)
            => _body.ContainsKey(key);

        public string Get(string key)
        {
            if (_body.ContainsKey(key))
                return _body[key];

            throw DomainEventException.FromInvalidKey(key, _domainEventName);
        }
        
    }
}
