using BlockBuster.Shared.Infrastructure.Resources.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Templates.Mail
{
    public class UserSignedUpWelcomeEmailTemplate : IMailTemplate
    {
        private string _body;
        private string _subject;        
        private string[] _receivers;
        
        public UserSignedUpWelcomeEmailTemplate(
            string subject, 
            string body,            
            string[] receivers)
        {
            _body = body;
            _subject = subject;
            _receivers = receivers;
        }

        public string Body() 
            => _body;
        public string Subject()
            => _subject;
        public string[] Receivers()
            => _receivers;
    }
}
