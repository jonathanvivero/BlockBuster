using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.GetUsers
{
    public class UserGetUsersRequest : AbstractRequest
    {

        public UserGetUsersRequest(IQueryCollection query): base(query)
        {
        }
    }
}
