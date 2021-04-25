using BlockBuster.FILM.Film.Domain.FilmAggregate.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate.Validators
{
    public class FilmFromExternalAPIValidator
    {
        public FilmFromExternalAPIValidator()
        {

        }

        public void ValidateExternalResponseStatus(IRestResponse response, string name)
        {
            if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
                throw FilmExternalApiException.FromExternalApiError(name);
        }

        public void ValidateExternalFilmCategory(FilmCategory category, string categoryName)
        { 
            if(category == null)
                throw FilmExternalApiException.FromExternalFilmCategoryNotFound(categoryName);
        }
    }
}
