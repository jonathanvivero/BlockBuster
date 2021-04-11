using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Exceptions
{
    public class DomainEventException: ValidationException
    {
        public DomainEventException(string message): base(message)
        {

        }


        public static DomainEventException FromInvalidRulesCount(string name)
        {
            return new DomainEventException(
                ValidationResources.DomainEventValidateBodyAndRulesEntriesCountNotMatch                
            );

        }
        public static DomainEventException FromInvalidRule(string key, string name) 
        {
            return new DomainEventException(string.Format(
                    ValidationResources.DomainEventValidateBodyRulesErrorMessage, key, name
                )
            );
        }

        public static DomainEventException FromInvalidKey(string key, string name)
        {
            return new DomainEventException(string.Format(
                    ValidationResources.DomainEventValidateBodyKeysErrorMessage, key, name
                )
            );
        }
        
    }
}
