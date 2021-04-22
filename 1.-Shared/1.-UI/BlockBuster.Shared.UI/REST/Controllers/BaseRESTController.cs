using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.Shared.UI.REST.Controllers
{
    public abstract class BaseRESTController : ControllerBase
    {
        private readonly IUseCaseBus _useCaseBus;        
        public BaseRESTController(IUseCaseBus useCaseBus)
        {
            _useCaseBus = useCaseBus;
        }

        protected IActionResult Dispatch(IRequest request)
        {            
            IResponse response = _useCaseBus
                .Dispatch(request);
                        
            return this.HandleResponse(response);
        }
    }
}
