﻿using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Application.UseCases.User.GetUsers;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Shared.Application.Bus.UseCase;
using System.Collections.Generic;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public interface IUserTranslator
    {
        UserCountry FromFindCountryByCodeResponseToUserCountry(IResponse resp);
        UserCountry FromFindCountryByIdResponseToUserCountry(IResponse resp);
        CountryDTO FromUserCountryToCountryDTO(Country country);
        IEnumerable<UserCountry> FromCountryListToUserCountryList(IResponse resp);
        
    }
}