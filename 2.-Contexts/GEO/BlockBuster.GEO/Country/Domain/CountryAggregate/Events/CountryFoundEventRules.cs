using BlockBuster.GEO.Country.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate.Events
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
