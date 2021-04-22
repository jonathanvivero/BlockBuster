using BlockBuster.IAM.Application.UseCases.User.SignUp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Testing.Domain.UserAggregate.Stub
{
    public class UserSignUpRequestStub
    {
        private static UserSignUpRequest Create(
            string id, 
            string email, 
            string password, 
            string repeatPassword, 
            string firstName, 
            string lastName, 
            string role, 
            CountryDTO country)
        {
            return new UserSignUpRequest(
                id, 
                email, 
                password, 
                repeatPassword, 
                firstName, 
                lastName, 
                role, 
                country
                );
        }

        public static UserSignUpRequest ByDefault()
        {
            return Create(
                UserIdStub.ByDefault().GetValue(),                
                UserEmailStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserPasswordStub.ByDefault().GetValue(),
                UserFirstNameStub.ByDefault().GetValue(),
                UserLastNameStub.ByDefault().GetValue(),
                UserRoleStub.ByDefault().GetValue(),
                CountryDTOStub.ByDefault()
                );
        }
    }
}
