using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator.Specifications
{
    public class DateTimeRuleValidatorSpecification
        : RuleValidatorSpecification
    {
        public override bool TypeIs(string type) 
            => DataTypeResources.DATETIME == type;
        protected override bool TryParse(string value)
         => DateTime.TryParse(value, out var result);
        
    }
}
