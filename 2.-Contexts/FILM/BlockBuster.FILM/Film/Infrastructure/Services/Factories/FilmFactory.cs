using BlockBuster.FILM.Film.Domain.FilmAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Factories
{
    public class FilmFactory : IFilmFactory
    {
        public Domain.FilmAggregate.Film Create(string id, 
            string name, 
            string description, 
            string categoryId,
            Category.Domain.FilmAggregate.Category category)
        {
            var filmId = new FilmId(id);
            var filmName = new FilmName(id);
            var filmDescription = new FilmDescription(id);
            var filmCategoryId = new FilmCategoryId(categoryId);
            var filmCategory = new FilmCategory(category);
            var filmCreatedAt = new FilmCreatedAt(DateTime.Now);
            var filmUpdatedAt = new FilmUpdatedAt(DateTime.Now);

            return Domain.FilmAggregate.Film.Create(filmId,
                filmName,
                filmDescription,
                filmCategoryId,
                filmCategory,
                filmCreatedAt,
                filmUpdatedAt);
        }
    }
}
