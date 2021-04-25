using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public interface IFilmFactory
    {
        Film Create(
            string id, 
            string name, 
            string description,
            string categoryId,
            Category.Domain.FilmAggregate.Category category);
    }
}
