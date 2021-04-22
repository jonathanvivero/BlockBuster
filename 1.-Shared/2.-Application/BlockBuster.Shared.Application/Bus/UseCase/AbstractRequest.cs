using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Application.Bus.UseCase
{
    public class AbstractRequest : IRequest
    {        
        private IDictionary<string, int> page;
        public AbstractRequest(IQueryCollection query)
        {            
            this.SetPage(query["page[number]"], query["page[size]"]);
        }

        private void SetPage(StringValues pageNumber, StringValues pageSize)
        {
            this.page = new Dictionary<string, int>();

            this.page.Add("number", int.TryParse(pageNumber, out int number) ? number : 1);
            this.page.Add("size", int.TryParse(pageSize, out int size) ? size : 25);
        }      

        public IDictionary<string, int> Page()
            => this.page;
    }
}
