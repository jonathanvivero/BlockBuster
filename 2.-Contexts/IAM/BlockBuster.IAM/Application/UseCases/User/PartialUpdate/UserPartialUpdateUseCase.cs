using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.PartialUpdate
{
    public class UserPartialUpdateUseCase : UseCaseBase
    {
        public UserPartialUpdateUseCase(IBlockBusterIAMContext context)
            :base(context)
        {

        }
        public override IResponse Execute(IRequest req)
        {
            return null;
            
        }
    }
}
