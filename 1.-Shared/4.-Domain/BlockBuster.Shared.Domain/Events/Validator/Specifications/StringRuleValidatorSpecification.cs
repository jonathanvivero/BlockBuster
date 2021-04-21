using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator.Specifications
{
    public class StringRuleValidatorSpecification
        : RuleValidatorSpecification
    {
        public override bool TypeIs(string type)
            => DataTypeResources.STRING == type;
        protected override bool TryParse(string value)
         => !string.IsNullOrWhiteSpace(value);
        
    }
}
