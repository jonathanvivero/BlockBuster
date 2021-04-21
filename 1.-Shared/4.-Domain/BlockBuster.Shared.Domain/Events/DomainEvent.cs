using BlockBuster.Shared.Domain.Events.Validator;
using BlockBuster.Shared.Domain.Exceptions;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace BlockBuster.Shared.Domain.Events
{
    public abstract class DomainEvent
    {
        protected string _aggregateId;
        protected string _eventName;
        protected DomainEventBody _body;
        protected ResourceManager _resourceManager;
        protected string _classType;

        public DomainEvent(string aggregateId, DomainEventBody body, ResourceManager resourceManager)
        {
            _aggregateId = aggregateId;
            _classType = this.GetType().Name;
            _resourceManager = resourceManager;
            SetBody(
                body.SetDomainName(
                    SetEventName()
                )
            );
        }

        private void SetBody(DomainEventBody body)
        {
            ValidateBody(body);
            _body = body;
        }

        private void ValidateBody(DomainEventBody body)
        {
            DomainEventRules rules = this.Rules();

            DomainEventRuleValidator.CheckRulesAgainstBody(Name(), rules, body);
            
            foreach (var key in body.Keys())
            {
                string ruleValue = rules.Get(key);
                string bodyValue = body.Get(key);

                DomainEventRuleValidator.ValidateRule(Name(), key, ruleValue, bodyValue);                                
            }

        }

        // protected abstract IDictionary<string, string> Rules();
        protected abstract DomainEventRules Rules();        
        protected string SetEventName()
        { 
            _eventName = _resourceManager.GetString(_classType);
            return _eventName;
        }

        public string Name()
            => this._eventName;        
        public string AggregateId() => _aggregateId;
        public DomainEventBody Body() => _body;
    }
}
