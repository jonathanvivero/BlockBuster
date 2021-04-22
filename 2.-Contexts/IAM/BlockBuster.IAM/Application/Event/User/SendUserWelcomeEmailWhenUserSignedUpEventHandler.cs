using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Domain.UserAggregate.Resources;
using BlockBuster.IAM.Infrastructure.Resources;
using BlockBuster.Shared.Application.Bus.Event;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;

namespace BlockBuster.IAM.Application.Events.User
{
    public class SendUserWelcomeEmailWhenUserSignedUpEventHandler : IEventHandler
    {
        private readonly IUseCaseBus useCaseBus;
        public SendUserWelcomeEmailWhenUserSignedUpEventHandler(IUseCaseBus useCaseBus)
        {
            this.useCaseBus = useCaseBus;

        }
        public void Handle(DomainEvent domainEvent)
        {
            DomainEventBody body = domainEvent.Body();

            this.useCaseBus.Dispatch(
                new SendUserWelcomeEmailRequest(
                    body.Get(UserResources.FieldEmail),
                    body.Get(UserResources.FieldFirstName),
                    body.Get(UserResources.FieldLastName)
                )
            );
        }

        public string[] SubscribeTo() 
        {
            return new string[]
            {
                //IAMResources.UserSignedUpEvent
            };
        }
    }
}
