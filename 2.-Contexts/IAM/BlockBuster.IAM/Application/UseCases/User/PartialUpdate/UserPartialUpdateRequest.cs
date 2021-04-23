using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlockBuster.IAM.Application.UseCases.User.PartialUpdate
{
    public class UserPartialUpdateRequest : IRequest
    {
        public string Id { get; set; }
        public string CurrentUserId { get; set; }
        public string Password { get; set; }
        public string FirstName {get;set;}        
        public string LastName {get;set;}        
    
        public UserPartialUpdateRequest()
        {

        }

    }
}
