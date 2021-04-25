using BlockBuster.GEO.Country.Domain.CountryAggregate;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.IAM.Infrastructure.Services.User;
using System;

namespace BlockBuster.IAM.Infrastructure.Factory
{
    public class UserFactory : IUserFactory
    {
        private readonly IHashing _hashing;        

        public UserFactory(IHashing hashing)
        {
            _hashing = hashing;
        }

        public User Create(
            string id,
            string email,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string role,
            string countryId,
            Country country)
        {            
            UserId userId = new UserId(id);
            UserCountryId userCountryId = new UserCountryId(countryId);
            UserEmail userEmail = new UserEmail(email);            
            UserPassword.Validate(password, repeatPassword);
            UserCountry userCountry = new UserCountry(country);
            UserRole userRole = new UserRole(role);
            UserFirstName userFirstName = new UserFirstName(firstName);
            UserLastName userLastName = new UserLastName(lastName);
            UserHashedPassword userHashedPassword = _hashing.Hash(password);

            return User.SignUp(
                userId,
                userEmail,
                userHashedPassword,
                userFirstName,
                userLastName,
                userRole,
                userCountryId,
                userCountry);
        }

        public User PartialUpdate(
           User user,
           string firstName,
           string lastName,
           string password
           )
        {
            if (!string.IsNullOrEmpty(firstName))
                user.UpdateField(new UserFirstName(firstName));
            
            if (!string.IsNullOrEmpty(lastName))
                user.UpdateField(new UserFirstName(firstName));
            
            if (!string.IsNullOrEmpty(password))
                user.UpdateField(_hashing.Hash(password));

            user.UpdateField(new UserUpdatedAt(DateTime.Now));

            return user;
        }


    }
}
