using BlockBuster.GEO.Country.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate.Events
{
    public class CountryCreatedEventBody : DomainEventBody
    {
        public CountryCreatedEventBody(Domain.CountryAggregate.Country entity)
        {
            Add(CountryResources.FieldId, entity.Id);
            Add(CountryResources.FieldCode, entity.Code);
            Add(CountryResources.FieldTax, entity.Tax);
        }
    }
}
