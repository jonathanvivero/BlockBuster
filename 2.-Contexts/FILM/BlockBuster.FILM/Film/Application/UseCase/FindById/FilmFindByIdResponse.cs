using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindById
{
    public class FilmFindByIdResponse : IResponse
    {
        public FilmDTO Film { get; private set; }
        public FilmFindByIdResponse(FilmDTO film)
        {
            Film = film;
        }
    }
}
