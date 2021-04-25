using BlockBuster.GEO.Country.Domain.CountryAggregate.Events;
using BlockBuster.Shared.Domain.Aggregates;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.GEO.Country.Domain.CountryAggregate
{
    public class Country: AggregateRoot
    {
        [Key]
        public CountryId Id { get; private set; }
        public CountryCode Code { get; private set; }
        public CountryTax Tax { get; private set; }
        public CountryCreatedAt CreatedAt { get; private set; }
        public CountryUpdatedAt UpdatedAt { get; private set; }

        public Country()
        { }

        private Country(CountryId id,
            CountryCode code,
            CountryTax tax,
            CountryCreatedAt createdAt,
            CountryUpdatedAt updatedAt)
        {
            this.Id = id;
            this.Code = code;
            this.Tax = tax;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        public static Country Create(
            CountryId id,
            CountryCode code,
            CountryTax tax,
            CountryCreatedAt createdAt,
            CountryUpdatedAt updatedAt)
        {
            var country = new Country(id, code, tax, createdAt, updatedAt);

            country.Record(
                new CountryCreatedEvent(
                    id.GetValue().ToString(),
                    new CountryCreatedEventBody(country)
                )
            );

            return country;
        }
    }
}
