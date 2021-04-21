using BlockBuster.GEO.Country.Application.UseCase.FindByCode;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.Testing.Domain.CountryAggregate.Stub;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using Moq;
using NUnit.Framework;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Services
{
    [TestFixture]
    public class UserFacadeTest
    {
        [Test]
        public void FindCountryFromCountryCodeShouldUseCollaborators()
        {
            var country = CountryStub.ByDefault();
            var userCountry = UserCountryStub.ByDefault();
            IResponse response = new FindCountryByCodeResponse(country);
            Mock<IUseCaseBus> useCaseBusMock = new Mock<IUseCaseBus>();
            Mock<IUserTranslator> userTranslatorMock = new Mock<IUserTranslator>();
            var userFacade = new UserFacade(useCaseBusMock.Object, userTranslatorMock.Object);
            useCaseBusMock
                .Setup(s => s.Dispatch(It.IsAny<IRequest>()))
                .Returns(response)
                .Verifiable();

            userTranslatorMock
                .Setup(s => s.FromFindCountryByCodeResponseToUserCountry(It.IsAny<IResponse>()))
                .Returns(userCountry)
                .Verifiable();

            Mock.VerifyAll();
        }       
    }
}
