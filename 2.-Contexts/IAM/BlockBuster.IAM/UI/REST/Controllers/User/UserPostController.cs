using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.UI.REST.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockBuster.IAM.UI.REST.Controllers.User
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserPostController: BaseRESTController
    {
        private readonly ILoggerFactory _loggerFactory;
        public UserPostController(
            IUseCaseBus useCaseBus,         
            IBlockBusterIAMContext context)
           : base(useCaseBus) 
        {            
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(SignUp))]
        public IActionResult SignUp(UserSignUpRequest request)
        {                        
            return Dispatch(request);             
        }

      
    }
}
