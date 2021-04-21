using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserTranslator: IUserTranslator
    {
        public UserCountry FromFindCountryByCodeResponseToUserCountry(IResponse resp)
        {
            FindCountryByCodeResponse response = resp as FindCountryByCodeResponse;
            return new UserCountry(response.Country);
        }
    }
}
