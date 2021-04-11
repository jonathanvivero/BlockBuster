using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.Country.Find
{
    public class FindCountryByCodeResponse: IResponse
    {
        public string Id { get; }
        public string Code { get; }
        public double Tax { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public FindCountryByCodeResponse(
            CountryId id,
            CountryCode code,
            CountryTax tax,
            CountryCreatedAt createdAt, 
            CountryUpdatedAt updatedAt)
        {
            this.Code = code.GetValue();
            this.Id = id.GetValue();
            this.Tax = tax.GetValue();
            this.CreatedAt = createdAt.GetValue();
            this.UpdatedAt = updatedAt.GetValue();
        }
    }
}
