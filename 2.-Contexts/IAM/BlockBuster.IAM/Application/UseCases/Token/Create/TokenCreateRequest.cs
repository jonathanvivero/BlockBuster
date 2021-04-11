using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Application.UseCases.Token.Create
{
    public class TokenCreateRequest : IRequest
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public TokenCreateRequest(
            string email,
            string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
