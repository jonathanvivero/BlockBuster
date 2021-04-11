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
        private readonly IBlockBusterContext _context;
        public BaseRESTController(IUseCaseBus useCaseBus, 
            IBlockBusterContext context)
        {
            _useCaseBus = useCaseBus;
            _context = context;
        }

        protected IActionResult Dispatch(IRequest request)
        {            
            IResponse response = _useCaseBus
                .Dispatch(request, _context);
            
            ExceptionResponseFacade exceptionResponseFacade =
                new ExceptionResponseFacade(this, response);
            
            return exceptionResponseFacade.HandleResponse();
        }
    }
}
