using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.PartialUpdate
{
    public class UserPartialUpdateRequest : AbstractRequest
    { 
        public string Id { get; private set; }
        public JsonPatchDocument<UserDTO> User { get; private set; }               
    
        public UserPartialUpdateRequest(IQueryCollection query)
        :base(query)
        {

        }

    }
}
