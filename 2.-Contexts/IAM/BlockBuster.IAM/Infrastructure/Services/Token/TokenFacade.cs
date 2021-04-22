using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;
using BlockBuster.IAM.Infrastructure.Services.User;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public class TokenFacade : ITokenFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAdapter _userAdapter;
        private readonly IHashing _hashingService;
        private readonly UserFindByEmailAndPasswordValidator _validator;
        public TokenFacade(IUserRepository userRepository, 
            IHashing hashingService, 
            IUserAdapter userAdapter,
            UserFindByEmailAndPasswordValidator validator)
        {
            _userRepository = userRepository;
            _hashingService = hashingService;
            _userAdapter = userAdapter;
            _validator = validator;
        }

        public Domain.UserAggregate.User FindUserFromEmailAndPassword(string email, string password)
        {
            var userHashedPassword = _hashingService.Hash(password);
            Domain.UserAggregate.User user = _userRepository.FindUserByEmailAndPassword(
                new UserEmail(email),
                userHashedPassword);

            _validator.Validate(user);

            user.SetUserCountry(
                _userAdapter.FindCountryFromCountryId(user.CountryId.GetValue())
            );

            return user;
        }       
    }
}
