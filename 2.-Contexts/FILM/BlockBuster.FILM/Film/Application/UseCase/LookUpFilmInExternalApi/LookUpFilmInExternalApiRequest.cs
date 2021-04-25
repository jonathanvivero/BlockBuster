using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.LookUpFilmInExternalApi
{
    public class LookUpFilmInExternalApiRequest: IRequest
    {
        public Domain.FilmAggregate.Film Film { get; private set; }
        public string Name { get; private set; }

        public LookUpFilmInExternalApiRequest(Domain.FilmAggregate.Film film, string name)
        {
            Film = film;
            Name = name;
        }
    }
}
