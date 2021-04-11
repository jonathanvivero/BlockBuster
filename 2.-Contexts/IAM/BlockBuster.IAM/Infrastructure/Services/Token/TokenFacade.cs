using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.IAM.Infrastructure.Services.Token
{
    public class TokenFacade
    {
        private readonly IUserRepository _userRepository;
        public TokenFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Domain.UserAggregate.User FindUserFromEmailAndPassword(string email, string password)
        {
            Domain.UserAggregate.User user = _userRepository.FindUserByEmail(new UserEmail(email));
            // TODO
            // use useCaseBus
            // check password
            return user;
        }
    }
}
