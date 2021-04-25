using BlockBuster.FILM.Film.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate.Exceptions
{
    public class FilmExternalApiException: WarningException
    {
        public FilmExternalApiException(string message) : base(message)
        {

        }

        public static FilmExternalApiException FromExternalApiError(string name)
        {
            return new FilmExternalApiException(
                string.Format(
                    FilmResources.ValidationExternalApiError, 
                    name
                )
            );
        }

        public static FilmExternalApiException FromExternalFilmCategoryNotFound(string name)
        {
            return new FilmExternalApiException(
                string.Format(
                    FilmResources.ValidationExternalFilmCategoryNotFound,
                    name
                )
            );
        }
    }


}
