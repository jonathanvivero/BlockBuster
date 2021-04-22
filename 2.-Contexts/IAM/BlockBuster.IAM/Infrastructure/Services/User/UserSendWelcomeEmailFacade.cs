using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserSendWelcomeEmailFacade: IUserSendWelcomeEmailFacade
    {
        private readonly IUseCaseBus _useCaseBus;
       
        public UserSendWelcomeEmailFacade(IUseCaseBus useCaseBus)
        {
            _useCaseBus = useCaseBus;        
        }

        public IResponse SendUserSignedUpWelcomeEmail(Domain.UserAggregate.User user)
        {
            var request = new SendUserWelcomeEmailRequest(
                user.Email.GetValue(),
                user.FirstName.GetValue(), 
                user.LastName.GetValue()
            );
            IResponse response = _useCaseBus.Dispatch(request);
            return response;
        }

    }
}
