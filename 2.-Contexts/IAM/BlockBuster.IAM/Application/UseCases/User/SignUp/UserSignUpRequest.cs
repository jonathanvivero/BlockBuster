
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Application.UseCases.User.SignUp
{
    public class UserSignUpRequest: IRequest
    {

        public string Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string RepeatPassword { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Role { get; private set; }
        public CountryDTO Country { get; private set; }

        public UserSignUpRequest(
            string id,
            string email,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string role,
            CountryDTO country)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.RepeatPassword = repeatPassword;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.Country = country;
        }
    }
}
