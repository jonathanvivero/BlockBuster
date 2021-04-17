using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Application.UseCases.Email
{
    public class SendUserWelcomeEmailRequest: IRequest
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public SendUserWelcomeEmailRequest(
            string email, 
            string firstName, 
            string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
