using BlockBuster.IAM.Application.UseCases.User.GetUsers;
using BlockBuster.IAM.Application.UseCases.User.SignUp;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.UI.REST.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.IAM.UI.REST.Controllers.User
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    public class UserGetController : BaseRESTController
    {
        public UserGetController(
            IUseCaseBus useCaseBus,
            IBlockBusterIAMContext context)
           : base(useCaseBus) { }

        [AllowAnonymous]
        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            UserGetUsersRequest request = new UserGetUsersRequest(HttpContext.Request.Query);
            return Dispatch(request);
        }
    }
}
