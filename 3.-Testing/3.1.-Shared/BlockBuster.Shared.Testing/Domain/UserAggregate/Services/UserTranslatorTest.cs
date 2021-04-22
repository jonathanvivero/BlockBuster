using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class UserTranslatorTest
    {
        [Test]
        public void FromFindCountryByCodeResponseToUserCountryShouldReturnValidUserCountryCountry()
        {
            
            var userTranslator = new UserTranslator();
            var country = CountryStub.ByDefault();
            IResponse resp = new FindCountryByCodeResponse(country);
            
            var actual = userTranslator
                .FromFindCountryByCodeResponseToUserCountry(resp);

            Assert.AreEqual(actual.GetValue().Code.GetValue(), country.Code.GetValue());            
        }        
    }
}
