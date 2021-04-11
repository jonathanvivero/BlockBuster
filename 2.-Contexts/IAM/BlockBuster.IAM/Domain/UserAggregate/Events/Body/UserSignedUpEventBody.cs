using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Domain.UserAggregate.Events.Body
{
    public class UserSignedUpEventBody: DomainEventBody
    {
        public UserSignedUpEventBody(User entity)
        {
            Add(UserResources.FieldEmail, entity.Email);
            Add(UserResources.FieldFirstName, entity.FirstName);
            Add(UserResources.FieldLastName, entity.LastName);
            Add(UserResources.FieldRole, entity.Role);
        }
    }
}
