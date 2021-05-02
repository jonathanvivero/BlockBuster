using BlockBuster.FILM.Film.Domain.FilmAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public interface IFilmFindByFilterLookUpInExternalApiFacade
    {
        Domain.FilmAggregate.Film FindFilmInExternalAPI(string name);
    }
}
