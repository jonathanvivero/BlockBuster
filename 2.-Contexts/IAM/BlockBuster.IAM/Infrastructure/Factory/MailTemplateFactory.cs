using BlockBuster.IAM.Infrastructure.Resources;
using BlockBuster.IAM.Infrastructure.Templates.Mail;
using BlockBuster.Shared.Infrastructure.Resources.Templates;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Factory
{
    public class MailTemplateFactory
    {                
        public UserSignedUpWelcomeEmailTemplate CreateUserSignedUpWelcomeEmail(
            string userSignedUpEmail,
            string userSignedUpFirstName, 
            string userSignedUpLastName)
        {
            var body = string.Format(
                        MailTemplateResources.UserSignedUpWelcomeEmailBody,
                        userSignedUpFirstName,
                        userSignedUpLastName,
                        userSignedUpEmail
                );
            var emailContent = new UserSignedUpWelcomeEmailTemplate(
                body,
                MailTemplateResources.UserSignedUpWelcomeEmailSubject,
                new string[] { userSignedUpEmail }
                );

            return emailContent;
        }
    }   
}
