using BlockBuster.IAM.Application.UseCases.User.PartialUpdate;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.UI.REST.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockBuster.IAM.UI.REST.Controllers.User
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserPatchController : BaseRESTController
    {
        public UserPatchController(
            IUseCaseBus useCaseBus,
            IBlockBusterIAMContext context)
           : base(useCaseBus) { }

        [AllowAnonymous]
        [HttpPatch("{id}", Name = nameof(PartialUpdate))]
        public IActionResult PartialUpdate()
        {
            var request = new UserPartialUpdateRequest(HttpContext.Request.Query);
            return Dispatch(request);
        }
    }
}
