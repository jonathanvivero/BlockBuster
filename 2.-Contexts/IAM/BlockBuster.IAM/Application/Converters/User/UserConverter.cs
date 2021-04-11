using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.IAM.Application.Converters.User
{
    public class UserConverter
    {
        public IResponse Convert()
        {
            return new UserSignUpResponse();
        }
    }
}
