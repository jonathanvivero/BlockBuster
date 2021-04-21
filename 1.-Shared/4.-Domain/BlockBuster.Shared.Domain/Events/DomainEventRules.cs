using BlockBuster.Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events
{
    public abstract class DomainEventRules
    {
        protected string _domainEventName;
        protected IDictionary<string, string> _rules;
        public int Count { get; private set; }
        public DomainEventRules(string name)
        {
            _domainEventName = name;
            _rules = new Dictionary<string, string>();
        }

        protected void Add(string rule, string type)
        {
            _rules.Add(rule, type);
            Count = _rules.Count;
        }

        public IEnumerable<string> Keys()
            => _rules.Keys;

        public bool Has(string key)
            => _rules.ContainsKey(key);

        public string Get(string key)
        {
            if (_rules.ContainsKey(key))
                return _rules[key];

            throw DomainEventException.FromInvalidKey(key, _domainEventName);
        }
        
    }
}
