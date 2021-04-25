using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Domain.FilmAggregate.Validators;
using BlockBuster.FILM.Film.Infrastructure.Resources;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public class FilmFindFromExternalAPIFacade : IFilmFindFromExternalAPIFacade
    {
        private readonly IFilmFactory _filmFactory;
        private readonly FilmFromExternalAPIValidator _filmFromExternalAPIValidator;
        private readonly IFilmFindCategoryFromCategoryNameFacade _filmFindCategoryFromCategoryName;

        public FilmFindFromExternalAPIFacade(IFilmFactory filmFactory,
            FilmFromExternalAPIValidator filmFromExternalAPIValidator,
            IFilmFindCategoryFromCategoryNameFacade filmFindCategoryFromCategoryName)
        {

        }

        public Domain.FilmAggregate.Film FindFilmInExternalAPI(
            string name,
            Func<string, FilmCategory> findCategoryByName
            )
        {
            var client = new RestClient(
                string.Format(FilmResources.FilmExternalApi, name)
            );
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            _filmFromExternalAPIValidator.ValidateExternalResponseStatus(response, name);

            FilmDTO filmDto = JsonConvert.DeserializeObject<FilmDTO>(response.Content);
            var filmCategory = findCategoryByName(filmDto.Category.Name);

            _filmFromExternalAPIValidator.ValidateExternalFilmCategory(filmCategory, filmDto.Category.Name);

            var film = _filmFactory.Create(
                filmDto.Id,
                filmDto.Name,
                filmDto.Description,
                filmCategory.GetValue().Id.GetValue(),
                filmCategory.GetValue()
            );

            return film;
        }
    }
}
