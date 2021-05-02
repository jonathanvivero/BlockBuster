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
    public class FilmFindByFilterLookUpInExternalApiFacade : IFilmFindByFilterLookUpInExternalApiFacade
    {
        private readonly IFilmFactory _filmFactory;
        private readonly FilmFromExternalAPIValidator _filmFromExternalAPIValidator;
        private readonly IFilmFindByFilterFindCategoryNameFacade _filmFindCategoryFromCategoryName;        

        public FilmFindByFilterLookUpInExternalApiFacade(IFilmFactory filmFactory,
            FilmFromExternalAPIValidator filmFromExternalAPIValidator,
            IFilmFindByFilterFindCategoryNameFacade filmFindCategoryFromCategoryName)
        {
            _filmFindCategoryFromCategoryName = filmFindCategoryFromCategoryName;
            _filmFromExternalAPIValidator = filmFromExternalAPIValidator;
            _filmFactory = filmFactory;
        }

        public Domain.FilmAggregate.Film FindFilmInExternalAPI(string name)
        {
            RestRequest request;
            RestClient client;
            IRestResponse response;

            request = new RestRequest(Method.GET);
            client = new RestClient(
                string.Format(FilmResources.FilmExternalApi, name)
            );
            response = client.Execute(request);

            _filmFromExternalAPIValidator.ValidateExternalResponseStatus(response, name);

            FilmDTO filmDto = JsonConvert.DeserializeObject<FilmDTO>(response.Content);
            var filmCategory = _filmFindCategoryFromCategoryName.FindCategoryFromCategoryName(filmDto.Category.Name);

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
