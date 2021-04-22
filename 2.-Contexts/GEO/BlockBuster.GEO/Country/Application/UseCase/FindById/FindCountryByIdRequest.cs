using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryByIdRequest: IRequest
    {
        public string Id { get; }

        public FindCountryByIdRequest(string id)
        {
            this.Id = id;
        }
    }
}
