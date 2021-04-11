using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Hashing
{
    public interface IHashing
    {
        UserHashedPassword Hash(string password);
    }
}
