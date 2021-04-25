using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindById
{
    public class FilmFindByIdRequest: AbstractRequest
    {        
        public string Id { get; private set; }
        public FilmFindByIdRequest(IQueryCollection query)
            :base(query)
        {
            Id = query[FilmResources.QueryFieldId];
        }
    }
}
