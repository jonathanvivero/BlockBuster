using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Application.UseCases.User.GetUsers;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserTranslator: IUserTranslator
    {
        public UserCountry FromFindCountryByCodeResponseToUserCountry(IResponse resp)
        {
            FindCountryByCodeResponse response = resp as FindCountryByCodeResponse;
            return new UserCountry(response.Country);
        }

        public UserCountry FromFindCountryByIdResponseToUserCountry(IResponse resp)
        {
            FindCountryByIdResponse response = resp as FindCountryByIdResponse;
            return new UserCountry(response.Country);
        }

        public CountryDTO FromUserCountryToCountryDTO(Country country)
        {
            return new CountryDTO(country.Id.GetValue(),
                country.Code.GetValue(),
                country.Tax.GetValue(),
                country.CreatedAt.GetValue(),
                country.UpdatedAt.GetValue()
                );
        }
    }
}
