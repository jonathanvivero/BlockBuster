using BlockBuster.Shared.Domain.Events.Validator.Specifications;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.Shared.Domain.Events.Validator
{
    public class DomainEventRuleValidator
    {
        public static void CheckRulesAgainstBody(string name, DomainEventRules rules, DomainEventBody body)
        {
            if (body.Count != rules.Count)
            {
                throw DomainEventException.FromInvalidRulesCount(name);
            }
        }
        public static void ValidateRule(string key, string domainName, string ruleValue, string bodyValue)
        {

            var specificationType = typeof(RuleValidatorSpecification);

            var specificationValidators = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(w => specificationType.IsAssignableFrom(w)
                    && !w.IsAbstract);

            var specificationValidator = specificationValidators
                .Select(s =>
                ((RuleValidatorSpecification)Activator.CreateInstance(s)))
                .Where(w => w.TypeIs(ruleValue))
                .FirstOrDefault();

            try
            {
                specificationValidator.IsValid(bodyValue, key, domainName);
            }
            catch (NullReferenceException)
            { 
                throw DomainEventException.FromInvalidRule(key, domainName);
            }                        
        }
    }
}
