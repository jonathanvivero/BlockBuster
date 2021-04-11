using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockBuster.IAM.Infrastructure.Services.Hashing
{
    public class DefaultHashing : IHashing
    {
        public UserHashedPassword Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            string hash;

            using (var algorithm = new SHA512Managed())
            {
                byte[] hashBytes = algorithm.ComputeHash(bytes);
                hash = Convert.ToBase64String(hashBytes);
            }

            return new UserHashedPassword(hash);
        }
    }
}
