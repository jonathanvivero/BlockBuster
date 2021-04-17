using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.User
{
    public class UserSendWelcomeEmailAdapter
    {
        private readonly UserSendWelcomeEmailFacade _userFacade;

        public UserSendWelcomeEmailAdapter(UserSendWelcomeEmailFacade userFacade)
        {
            _userFacade = userFacade;
        }
        public IResponse SendUserSignedUpWelcomeEmail(Domain.UserAggregate.User user)
        {
            return _userFacade.SendUserSignedUpWelcomeEmail(user);
        }
    }
}
