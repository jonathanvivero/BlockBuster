using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Events.Rules
{
    public class UserSignedUpEventRules : DomainEventRules
    {        
        public UserSignedUpEventRules(string name) : base(name)
        {
            Add(UserResources.FieldEmail, DataTypeResources.STRING);
            Add(UserResources.FieldFirstName, DataTypeResources.STRING);
            Add(UserResources.FieldLastName, DataTypeResources.STRING);
            Add(UserResources.FieldRole, DataTypeResources.STRING);            
        }
    }
}
