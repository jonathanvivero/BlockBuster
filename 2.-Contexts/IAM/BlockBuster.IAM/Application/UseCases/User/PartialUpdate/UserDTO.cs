using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.PartialUpdate
{
    public class UserDTO
    {
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
