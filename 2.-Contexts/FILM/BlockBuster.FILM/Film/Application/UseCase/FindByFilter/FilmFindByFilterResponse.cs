using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindByFilter
{
    public class FilmFindByFilterResponse: IResponse
    {
        public IEnumerable<FilmDTO> Films { get; private set; }
        public FilmFindByFilterResponse(IEnumerable<FilmDTO> films)
        {
            Films = films;
        }
    }
}
