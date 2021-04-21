using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.IAM.Infrastructure.Services.Token;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class UserAdapterTest
    {
        [Test]
        public void FindCountryFromCountryCodeShouldUseCollaborators() 
        {
            var userFacadeMock = new Mock<IUserFacade>();
            var userCountry = UserCountryStub.ByDefault();
            var countryCode = CountryCodeStub.ByDefault().GetValue();
            var userAdapter = new UserAdapter(
                userFacadeMock.Object);

            userFacadeMock
                .Setup(s => s.FindCountryFromCountryCode(It.IsAny<string>()))
                .Returns(userCountry)
                .Verifiable();            

            var actual = userAdapter.FindCountryFromCountryCode(countryCode);

            Assert.AreEqual(actual.GetValue().Code.GetValue(), countryCode);
            userFacadeMock.Verify();            
        }       
    }
}
