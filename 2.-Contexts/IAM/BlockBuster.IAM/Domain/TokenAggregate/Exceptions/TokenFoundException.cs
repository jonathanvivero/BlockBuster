using BlockBuster.IAM.Domain.TokenAggregate.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlockBuster.IAM.Domain.TokenAggregate.Exceptions
{
    public class TokenFoundException : ValidationException
    {
        public TokenFoundException(string message) : base(message)
        {

        }

        public static TokenFoundException FromExistingUserId()
        {
            return new TokenFoundException(TokenResources.ValidationUserHasToken);
        }

    }
}
