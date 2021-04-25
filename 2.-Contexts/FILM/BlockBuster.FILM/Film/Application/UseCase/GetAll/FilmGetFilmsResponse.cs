using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.GetAll
{
    public class FilmGetFilmsResponse: IResponse
    {
        public FilmGetFilmsResponse(IEnumerable<FilmDTO> films)
        {
            Films = films;
        }
        public IEnumerable<FilmDTO> Films { get; private set; }
    }
}
