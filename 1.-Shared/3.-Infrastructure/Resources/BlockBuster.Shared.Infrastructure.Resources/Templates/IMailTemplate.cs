using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Resources.Templates
{
    public interface IMailTemplate
    {
        string Subject();
        string Body();
        string[] Receivers();
    }

}
