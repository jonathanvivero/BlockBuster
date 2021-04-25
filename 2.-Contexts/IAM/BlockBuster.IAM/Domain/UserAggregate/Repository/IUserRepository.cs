using System.Collections.Generic;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;

namespace BlockBuster.IAM.Domain.UserAggregate.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        User FindUserByEmail(UserEmail userEmail);
        User FindUserById(UserId userId);
        User FindUserByEmailAndPassword(UserEmail userEmail, UserHashedPassword password);
        IEnumerable<User> GetUsers(IDictionary<string, int> page);
    }
}
