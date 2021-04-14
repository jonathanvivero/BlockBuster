using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.Middleware.Exceptions;
using JsonApiSerializer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.UI.REST.Controllers
{
    public static class ResponseManagementExtensionFacade
    {        
        public static IActionResult HandleResponse(this BaseRESTController controller, IResponse response)
        {
            if (!(response is ExceptionResponse))
            {
                string json = JsonConvert.SerializeObject(response, new JsonApiSerializerSettings());

                return controller.Ok(json);
            }

            int code = int.Parse(((ExceptionResponse)response).Code);

            if(code == 400)
                return controller.BadRequest(response);
            
            if (code == 403)
                return controller.Forbid();
            
            if (code == 404)
                return controller.NotFound(response);
            
            return controller.StatusCode(code, response);
        }
    }
}
