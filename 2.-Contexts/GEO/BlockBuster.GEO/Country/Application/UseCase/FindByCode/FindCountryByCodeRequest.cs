using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryByCodeRequest: IRequest
    {
        public string Code { get; }

        public FindCountryByCodeRequest(string code)
        {
            this.Code = code;
        }
    }
}
