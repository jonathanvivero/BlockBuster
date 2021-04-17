using BlockBuster.IAM.Infrastructure.Templates.Mail;
using BlockBuster.Shared.Infrastructure.Resources.Templates;
using Microsoft.Extensions.Configuration;

namespace BlockBuster.IAM.Infrastructure.Services.Mailer
{
    public class Mailer: IMailer
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpServer;
        private readonly string _smtpUser;
        private readonly string _smtpPassword;

        public Mailer(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpServer = _configuration
                .GetSection("AppSettings:MailSettings:SMTP")
                .Value;
            _smtpUser = _configuration
                .GetSection("AppSettings:MailSettings:user")
                .Value;
            _smtpPassword = _configuration
                .GetSection("AppSettings:MailSettings:password")
                .Value;
        }
        public void SendEmail(IMailTemplate mailMessage)            
        {
            //TODO
            //SendEmail using smtp parameteres
            //and mailContent content
        }
       
    }
}
