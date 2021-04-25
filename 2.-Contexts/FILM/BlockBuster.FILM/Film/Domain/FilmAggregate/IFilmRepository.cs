using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public interface IFilmRepository
    {
        Film FindByName(FilmName name);
        Film FindById(FilmId id);
        IEnumerable<Film> GetAllFilms();
        void Add(Film film);
    }
}
