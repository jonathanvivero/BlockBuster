using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Application.Bus.UseCase
{
    public class AbstractPostRequest : IRequest
    {        
        public AbstractPostRequest(object query)
        {                        
        }

    }
}
