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
    public class ExceptionResponseFacade
    {
        private readonly ControllerBase _controller;
        private readonly IResponse _response;
        public ExceptionResponseFacade(ControllerBase controller, IResponse response)
        {
            _controller = controller;
            _response = response;
        }

        public IActionResult HandleResponse()
        {
            if (!(_response is ExceptionResponse))
            {
                string json = JsonConvert.SerializeObject(_response, new JsonApiSerializerSettings());

                return _controller.Ok(json);
            }

            int code = int.Parse(((ExceptionResponse)_response).Code);

            if(code == 400)
                return _controller.BadRequest(_response);
            
            if (code == 403)
                return _controller.Forbid();
            
            if (code == 404)
                return _controller.NotFound(_response);
            
            return _controller.StatusCode(code, _response);
        }
    }
}
