using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.IAM.Infrastructure.Services.User;

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
            Country country)
        {            
            UserId userId = new UserId(id);
            UserEmail userEmail = new UserEmail(email);

            UserPassword.Validate(password, repeatPassword);

            UserRole userRole = new UserRole(role);
            UserFirstName userFirstName = new UserFirstName(firstName);
            UserLastName userLastName = new UserLastName(lastName);
            UserCountry userCountryCode = new UserCountry(country);
            UserHashedPassword userHashedPassword = _hashing.Hash(password);

            return User.SignUp(
                userId,
                userEmail,
                userHashedPassword,
                userFirstName,
                userLastName,
                userRole,
                userCountryCode);
        }
    }
}
