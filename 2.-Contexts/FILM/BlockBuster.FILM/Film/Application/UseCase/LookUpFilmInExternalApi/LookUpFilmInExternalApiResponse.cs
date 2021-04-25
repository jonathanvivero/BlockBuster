using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.LookUpFilmInExternalApi
{
    public class LookUpFilmInExternalApiResponse: IResponse
    {
        public Domain.FilmAggregate.Film Film { get; private set; }

        public LookUpFilmInExternalApiResponse(Domain.FilmAggregate.Film film)
        {
            Film = film;
        }
    }
}
