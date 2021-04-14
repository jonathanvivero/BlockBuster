using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;

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
            string countryId)
        {            
            UserId userId = new UserId(id);
            UserCountryId userCountryId = new UserCountryId(countryId);
            UserEmail userEmail = new UserEmail(email);

            UserPassword.Validate(password, repeatPassword);

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
                userCountryId);
        }
    }
}
