using BlockBuster.IAM.Domain.UserAggregate;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.IAM.Infrastructure.Presistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public UserRepository(IBlockBusterIAMContext context, 
            IServiceScopeFactory serviceScopeFactory)
            : base(context)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public User FindUserByEmail(UserEmail userEmail)
        {
            // return this.context.Users.FirstOrDefault(w => w.userEmail.GetValue() == userEmail.GetValue());

            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterIAMContext>();
                return dbContext.Users.FirstOrDefault(w => w.Email.GetValue() == userEmail.GetValue());
            }
        }

        public User FindUserByEmailAndPassword(UserEmail userEmail, UserHashedPassword userHashedPassword)
        {
            // return this.context.Users.FirstOrDefault(w => w.userEmail.GetValue() == userEmail.GetValue());

            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterIAMContext>();
                return dbContext.Users
                    .Where(w => w.Email.Equals(userEmail)
                        && w.HashedPassword.Equals(userHashedPassword)
                    )
                    .FirstOrDefault();
            }
        }

        public override void Add(User user)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterIAMContext>();
                dbContext.Users.Add(user);
            }
        }

        public IEnumerable<User> GetUsers(IDictionary<string, int> page)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IBlockBusterIAMContext>();
                return db.Users
                    .Skip((page["number"] - 1) * page["size"])
                    .Take(page["size"]);
            }
        }
    }
}
