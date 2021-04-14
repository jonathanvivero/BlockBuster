using BlockBuster.IAM.Domain.TokenAggregate;
using BlockBuster.IAM.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.Infrastructure.Persistence.Context
{
    public interface IBlockBusterIAMContext: IBlockBusterContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Token> Tokens { get; set; }
    }
}
