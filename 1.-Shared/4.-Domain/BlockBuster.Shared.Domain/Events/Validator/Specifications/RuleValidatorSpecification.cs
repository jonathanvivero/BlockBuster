using BlockBuster.Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator.Specifications
{
    public abstract class RuleValidatorSpecification        
    {
        protected abstract bool TryParse(string value);
        public abstract bool TypeIs(string type);
        public void IsValid(string bodyValue, string key, string domainEventName)
        {
            if(!TryParse(bodyValue))
                throw DomainEventException.FromInvalidRule(key, domainEventName);
        }
        
    }
}
