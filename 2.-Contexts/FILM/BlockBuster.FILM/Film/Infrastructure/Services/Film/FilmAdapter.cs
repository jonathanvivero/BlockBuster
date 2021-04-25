using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public class FilmAdapter: IFilmAdapter
    {

        private readonly IFilmFindFromExternalAPIFacade _filmFindFromExternalAPIFacade;
        private readonly IFilmFindCategoryFromCategoryNameFacade _filmFindCategoryFromCategoryName;
        public FilmAdapter(IFilmFindFromExternalAPIFacade filmFindFromExternalAPIFacade,
            IFilmFindCategoryFromCategoryNameFacade filmFindCategoryFromCategoryName)
        {         
            _filmFindFromExternalAPIFacade = filmFindFromExternalAPIFacade;
            _filmFindCategoryFromCategoryName = filmFindCategoryFromCategoryName;
        }

        public FilmCategory FindCategoryFromCategoryName(string name)
        {
            return _filmFindCategoryFromCategoryName.FindCountryFromCountryCode(name);
        }

        public Domain.FilmAggregate.Film LookUpInExternalApi(string name)
        {
            return _filmFindFromExternalAPIFacade.FindFilmInExternalAPI(name, FindCategoryFromCategoryName);
        }
    }
}
