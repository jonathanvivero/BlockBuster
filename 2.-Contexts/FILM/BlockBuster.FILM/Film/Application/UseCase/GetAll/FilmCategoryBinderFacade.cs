using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Domain.FilmAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.GetAll
{
    public class FilmCategoryBinderFacade
    {
        public FilmCategoryBinderFacade()
        {

        }
        
        public IEnumerable<Domain.FilmAggregate.Film> Bind(IEnumerable<Domain.FilmAggregate.Film> films, IDictionary<string, Category.Domain.FilmAggregate.Category> categories)
        {
            return films
                .Select(s => 
                    Bind(s, categories)
                );
        }

        public Domain.FilmAggregate.Film Bind(Domain.FilmAggregate.Film film, IDictionary<string, Category.Domain.FilmAggregate.Category> categories)
        {
            if (!categories.ContainsKey(film.CategoryId.GetValue()))
                throw FilmAttributeException.FromCategoryNotFound(film);

            film.SetCategory(
                new FilmCategory(
                    categories[film.CategoryId.GetValue()]
                )
            );

            return film;
        }
    }
}
