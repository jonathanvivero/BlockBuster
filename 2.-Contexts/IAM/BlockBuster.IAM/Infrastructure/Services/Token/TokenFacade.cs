using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.Hashing;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public class TokenFacade : ITokenFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashing _hashingService;
        private readonly UserFindByEmailAndPasswordValidator _validator;
        public TokenFacade(IUserRepository userRepository, 
            IHashing hashingService, 
            UserFindByEmailAndPasswordValidator validator)
        {
            _userRepository = userRepository;
            _hashingService = hashingService;
            _validator = validator;
        }

        public Domain.UserAggregate.User FindUserFromEmailAndPassword(string email, string password)
        {
            var userHashedPassword = _hashingService.Hash(password);
            Domain.UserAggregate.User user = _userRepository.FindUserByEmailAndPassword(
                new UserEmail(email),
                userHashedPassword);

            _validator.Validate(user);
            // TODO
            // use useCaseBus
            // check password
            return user;
        }
    }
}
