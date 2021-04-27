using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindByFilter
{
    public class FilmFindByFilterRequest: AbstractRequest
    {
        public FilmFindByFilterRequest(IQueryCollection query)
            : base(query)
        {

        }
    }
}
