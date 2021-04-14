using BlockBuster.IAM.Application.UseCases.User.SignUp;

namespace BlockBuster.IAM.Domain.UserAggregate.Factories
{
    public interface IUserFactory
    {
        User Create(
            string id,
            string email,
            string password,
            string repeatPassword,
            string firstName,
            string lastName,
            string role,
            string countryId);
    }
}
