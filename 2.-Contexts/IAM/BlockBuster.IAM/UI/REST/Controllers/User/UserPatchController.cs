using BlockBuster.IAM.Application.UseCases.User.PartialUpdate;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Security.Authentication;
using BlockBuster.Shared.UI.REST.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlockBuster.IAM.UI.REST.Controllers.User
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserPatchController : BaseRESTController
    {
        public UserPatchController(
            IUseCaseBus useCaseBus,
            IBlockBusterIAMContext context)
           : base(useCaseBus) { }
        [Authorize(Roles = UserRole.ALL_ROLES)]
        [HttpPatch("{id}", Name = nameof(PartialUpdate))]
        public IActionResult PartialUpdate(string id, [FromBody] JsonPatchDocument<UserPartialUpdateRequest> patchDoc)
        {
            UserPartialUpdateRequest request = new UserPartialUpdateRequest();
            request.Id = id;            
            patchDoc.ApplyTo(request, ModelState);
            return this.Dispatch(request);
        }
    }
}
