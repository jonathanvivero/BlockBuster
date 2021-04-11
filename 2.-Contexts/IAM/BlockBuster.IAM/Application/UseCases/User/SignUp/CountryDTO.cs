using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.SignUp
{
    public class CountryDTO
    {
        public string Code { get; }

        public CountryDTO(string code)
        {
            this.Code = code;
        }
    }
}
