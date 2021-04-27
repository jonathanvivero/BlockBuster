using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.Shared.Application.Bus.UseCase
{
    public class AbstractRequest : IRequest
    {        
        private IDictionary<string, int> _page;
        private IDictionary<string, string[]> _filter;
        public AbstractRequest(IQueryCollection query)
        {            
            this.SetPage(query["page[number]"], query["page[size]"]);
            this.SetFilters(query.Keys.Where(s => s.StartsWith("filter[")));
            
        }

        private void SetPage(StringValues pageNumber, StringValues pageSize)
        {
            _page = new Dictionary<string, int>();

            _page.Add("number", int.TryParse(pageNumber, out int number) ? number : 1);
            _page.Add("size", int.TryParse(pageSize, out int size) ? size : 25);
        }

        private void SetFilters(IEnumerable<string> filters)
        { 
            _filter = new Dictionary<string, string[]>();

            if (!filters.Any())
                return;

            foreach (var filter in filters)
            {
                var start = filter.IndexOf('[') + 1;
                var length = filter.IndexOf(']') - start;
                var filterKey = filter.Substring(start, length);
                var filterValue = filter.Split('=')[1];
                _filter.Add(filterKey, filterValue.Split(','));
            }
        }

        public IDictionary<string, int> Page { get => _page; }
        public IDictionary<string, string[]> Filter { get => _filter; }
    }
}
