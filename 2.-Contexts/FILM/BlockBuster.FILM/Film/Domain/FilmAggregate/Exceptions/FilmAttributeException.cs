using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate.Exceptions
{
    public class FilmAttributeException: InvalidAttributeException
    {
        private FilmAttributeException(string message): base(message)
        {

        }

        public static FilmAttributeException FromCategoryNotFound(Domain.FilmAggregate.Film film)
        {
            return new FilmAttributeException(
                string.Format(
                    FilmResources.ValidationCategoryNotFound,
                    film.Name.GetValue(),
                    film.CategoryId.GetValue()
                )
            );
        }


    }
}
