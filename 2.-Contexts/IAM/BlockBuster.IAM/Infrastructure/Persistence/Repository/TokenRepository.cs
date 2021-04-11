using BlockBuster.IAM.Domain.TokenAggregate;
using BlockBuster.IAM.Domain.TokenAggregate.Repository;
using BlockBuster.IAM.Domain.TokenAggregate.ValueObjects;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BlockBuster.IAM.Infrastructure.Presistence.Repositories
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public TokenRepository(
            IBlockBusterIAMContext context, 
            IServiceScopeFactory serviceScopeFactory)
            : base(context)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Token FindTokenByUserId(TokenUserId userId)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterIAMContext>();
                return dbContext.Tokens.FirstOrDefault(w => w.UserId.GetValue() == userId.GetValue());
            }
        }

        public override void Add(Token token)
        {
            using (var scope = this.serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IBlockBusterIAMContext>();
                dbContext.Tokens.Add(token);
            }
        }
    }
}
