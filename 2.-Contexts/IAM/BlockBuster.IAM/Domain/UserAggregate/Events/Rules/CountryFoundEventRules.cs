using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Events.Rules
{
    public class CountryFoundEventRules : DomainEventRules
    {        
        public CountryFoundEventRules(string name) : base(name)
        {
            Add(CountryResources.FieldCode, DataTypeResources.STRING);
            Add(CountryResources.FieldTax, DataTypeResources.DOUBLE);            
        }
    }
}
