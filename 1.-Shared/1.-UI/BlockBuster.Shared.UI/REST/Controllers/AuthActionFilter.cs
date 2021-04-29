using BlockBuster.Shared.Infrastructure.Security.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BlockBuster.Shared.UI.REST.Controllers
{
    public class AuthActionFilter : IActionFilter
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthActionFilter(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Claim claim = null;
            _authenticationService.Set(211);
            var userClaims = context
                .HttpContext
                .User
                .Claims;
            if (userClaims.Any())
                claim = userClaims.FirstOrDefault(w => w.Type == ClaimTypes.NameIdentifier);
            if (claim != null)
                Console.WriteLine(claim.Value);
                
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
