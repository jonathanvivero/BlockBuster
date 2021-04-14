using BlockBuster.GEO.Country.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.GEO.Country.Domain.UserAggregate.Events
{
    public class CountryFoundEventBody : DomainEventBody
    {
        public CountryFoundEventBody(Domain.CountryAggregate.Country entity)
        {
            Add(CountryResources.FieldCode, entity.Code);
            Add(CountryResources.FieldTax, entity.Tax);
        }
    }
}
