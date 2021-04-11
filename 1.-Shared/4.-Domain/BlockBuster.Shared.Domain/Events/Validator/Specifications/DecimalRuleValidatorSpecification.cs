using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator.Specifications
{
    public class DecimalRuleValidatorSpecification
        : RuleValidatorSpecification
    {
        public override bool TypeIs(string type)
            => DataTypeResources.DECIMAL == type;
        protected override bool TryParse(string value)
         => decimal.TryParse(value, out var result);
        
    }
}
