using BlockBuster.FILM.Film.Application.UseCase.FindById;
using BlockBuster.FILM.Film.Application.UseCase.FindByName;
using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.GetAll
{
    public class FilmGetFilmsRequest : AbstractRequest
    {
        public FilmGetFilmsRequest(IQueryCollection query)
            :base(query)
        {            
        }
    }
}
