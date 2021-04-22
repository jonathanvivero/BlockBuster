using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.Shared.Testing.Domain.UserAggregate.Stub;
using BlockBuster.IAM.Domain.UserAggregate.Exceptions;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Validators
{
    [TestFixture]
    public class UserSignCountryExistsValidatorTest
    {
        UserSignUpCountryExistsValidator validator;
        string countryCode;

        [SetUp]
        public void Setup()
        {
            validator = new UserSignUpCountryExistsValidator();
            countryCode = CountryDTOStub.ByDefault().Code;
        }

        [Test]
        public void ValidatorShouldValidateCountryIsNotNull()
        {
            object country = new object();

            void dlg() => validator.Validate(country, countryCode);

            Assert.DoesNotThrow(dlg);

        }

        [Test]
        public void ValidatorShouldThrowErrorByNullCountry()
        {
            object country = null;

            void dlg() => validator.Validate(country, countryCode);

            Assert.Throws<UserFoundException>(dlg);
        }
    }
}
