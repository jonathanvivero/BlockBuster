using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.GEO.Country.Application.UseCase.FindByCode
{
    public class FindCountryIdByCodeRequest: IRequest
    {
        public string Code { get; }

        public FindCountryIdByCodeRequest(string code)
        {
            this.Code = code;
        }
    }
}
