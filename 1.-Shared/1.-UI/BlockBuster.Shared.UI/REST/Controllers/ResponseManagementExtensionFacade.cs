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
                string responseJSON = JsonConvert.SerializeObject(response, new JsonApiSerializerSettings());
                var jsonObjectResult = JsonConvert.DeserializeObject(responseJSON, new JsonApiSerializerSettings());

                return controller.Ok(jsonObjectResult);
            }

            int code = int.Parse(((ExceptionResponse)response).Code);

            if (code == 204)
                return controller.NoContent();

            if(code == 400)
                return controller.BadRequest(response);
            
            if (code == 401)
                return controller.Unauthorized();

            if (code == 403)
                return controller.Forbid();
            
            if (code == 404)
                return controller.NotFound(response);
            
            return controller.StatusCode(code, response);
        }
    }
}
