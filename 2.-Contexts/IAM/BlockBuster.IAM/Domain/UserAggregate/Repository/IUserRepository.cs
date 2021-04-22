using System.Collections.Generic;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User FindUserByEmail(UserEmail userEmail);
        User FindUserByEmailAndPassword(UserEmail userEmail, UserHashedPassword password);
        IEnumerable<User> GetUsers(IDictionary<string, int> page);
    }
}
