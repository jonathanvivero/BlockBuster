using BlockBuster.IAM.Infrastructure.Factory;
using BlockBuster.IAM.Infrastructure.Services.Mailer;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockBuster.IAM.Application.UseCases.Email
{
    public class SendUserWelcomeEmailUseCase : UseCaseBase
    {
        private readonly IMailer _mailer;
        private readonly MailTemplateFactory _mailTemplateFactory;
        public SendUserWelcomeEmailUseCase(
            IMailer mailer,
            MailTemplateFactory mailTemplateFactory, 
            IBlockBusterIAMContext context)
            :base(context)
        {
            _mailer = mailer;
            _mailTemplateFactory = mailTemplateFactory;
        }

        public override IResponse Execute(IRequest req)
        {
            SendUserWelcomeEmailRequest request = req as SendUserWelcomeEmailRequest;

            var _userSignedUpWellcomeEmailTemplate =
                _mailTemplateFactory.CreateUserSignedUpWelcomeEmail(
                    request.Email, 
                    request.FirstName, 
                    request.LastName
                    );
                
            _mailer.SendEmail(_userSignedUpWellcomeEmailTemplate);

            return new SendUserWelcomeEmailResponse();

        }

        
    }
}
