using BlockBuster.FILM.Film.Domain.FilmAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public interface IFilmFindFromExternalAPIFacade
    {
        Domain.FilmAggregate.Film FindFilmInExternalAPI(string name, Func<string, FilmCategory> findCategoryByName);
    }
}
