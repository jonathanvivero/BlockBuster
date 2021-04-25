using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindByName
{
    public class FilmFindByNameResponse : IResponse
    {
        public FilmDTO Film { get; private set; }
        public FilmFindByNameResponse(FilmDTO film)
        {
            Film = film;
        }
    }
}
