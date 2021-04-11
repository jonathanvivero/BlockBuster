using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator.Specifications
{
    public class IntegerRuleValidatorSpecification
        : RuleValidatorSpecification
    {
        public override bool TypeIs(string type)
            => DataTypeResources.INT == type;
        protected override bool TryParse(string value)
         => int.TryParse(value, out var result);
        
    }
}
