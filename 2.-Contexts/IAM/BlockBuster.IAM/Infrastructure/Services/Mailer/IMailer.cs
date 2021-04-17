using BlockBuster.Shared.Infrastructure.Resources.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Mailer
{
    public interface IMailer        
    {
        void SendEmail(IMailTemplate mailMessage);            
    }
}
