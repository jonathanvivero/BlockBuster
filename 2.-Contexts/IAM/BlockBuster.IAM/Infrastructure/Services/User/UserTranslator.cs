using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserTranslator
    {
        public UserCountryId FromFindCountryIdByCodeResponseToUserCountryId(IResponse resp)
        {
            FindCountryIdByCodeResponse response = resp as FindCountryIdByCodeResponse;
            return new UserCountryId(response.Id);
        }
    }
}
