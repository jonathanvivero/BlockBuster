using BlockBuster.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.Shared.Application.Bus.UseCase
{
    public abstract class UseCaseBase 
        : IUseCase
    {
        protected string _context;
        public UseCaseBase(IBlockBusterContext context) 
        {
            _context = context
                .GetType()
                .FullName
                .Split('.')
                .LastOrDefault();
        }
        public abstract IResponse Execute(IRequest req);

        public string GetContextName()
            => _context;
    }
}
