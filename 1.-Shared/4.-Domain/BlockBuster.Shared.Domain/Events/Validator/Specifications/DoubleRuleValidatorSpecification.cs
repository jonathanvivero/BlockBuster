using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator.Specifications
{
    public class DoubleRuleValidatorSpecification
        : RuleValidatorSpecification
    {
        public override bool TypeIs(string type)
            => DataTypeResources.DOUBLE == type;
        protected override bool TryParse(string value)
         => double.TryParse(value, out var result);
        
    }
}
