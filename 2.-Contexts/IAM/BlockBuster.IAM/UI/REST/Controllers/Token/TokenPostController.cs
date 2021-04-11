using BlockBuster.IAM.Application.UseCases.Token.Create;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.UI.REST.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.Presentation.REST.Controllers.Tokens
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/token")]
    [ApiController]
    public class TokenPostController : BaseRESTController
    {
        public TokenPostController(
            IUseCaseBus useCaseBus,
            IBlockBusterIAMContext context)
            : base(useCaseBus, context) { }

        [AllowAnonymous]
        [HttpPost(Name = nameof(Create))]
        public IActionResult Create(TokenCreateRequest request)
        {
            return Dispatch(request);
        }

    }
}
