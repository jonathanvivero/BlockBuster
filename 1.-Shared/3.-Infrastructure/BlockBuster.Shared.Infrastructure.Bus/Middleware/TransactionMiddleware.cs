using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlockBuster.Shared.Infrastructure.Bus.Middleware
{
    public class TransactionMiddleware<TContext> : MiddlewareHandler
        where TContext: IBlockBusterContext
    {
        private TContext blockBusterContext;

        public TransactionMiddleware(TContext craftCodeContext)
        {
            this.blockBusterContext = craftCodeContext;
        }

        public override IResponse Handle(IRequest request)
        {
            IDbContextTransaction transaction = null;

            try
            {
                IResponse response = base.Handle(request);

                transaction = this.blockBusterContext
                    .Database
                    .BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                this.blockBusterContext.SaveChanges();
                transaction.Commit();

                return response;
            }
            catch (System.Exception exception)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw exception;
            }

        }
    }
}
