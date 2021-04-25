using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindByName
{
    public class FilmFindByNameRequest: AbstractRequest
    {
        public string Name { get; private set; }
        public FilmFindByNameRequest(IQueryCollection query)
            :base(query)
        {
            Name = query[FilmResources.QueryFieldName];
        }
    }
}
