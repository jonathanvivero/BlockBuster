using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.GetUsers
{
    public class UserGetUsersResponse: IResponse
    {
        public UserDTO[] Users { get; private set; }

        public UserGetUsersResponse(UserDTO[] users)
        {
            Users = users;
        }
    }
}
