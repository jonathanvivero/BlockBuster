using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Events.Body
{
    public class CountryFoundEventBody : DomainEventBody
    {
        public CountryFoundEventBody(Country entity)
        {
            Add(CountryResources.FieldCode, entity.Code);
            Add(CountryResources.FieldTax, entity.Tax);
        }
    }
}
