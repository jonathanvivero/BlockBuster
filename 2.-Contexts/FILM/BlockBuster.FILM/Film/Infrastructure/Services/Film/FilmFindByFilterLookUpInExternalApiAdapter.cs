using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public class FilmFindByFilterLookUpInExternalApiAdapter: IFilmFindByFilterLookUpInExternalApiAdapter
    {
                

        private readonly IFilmFindByFilterLookUpInExternalApiFacade _filmFindFromExternalAPIFacade;
        public FilmFindByFilterLookUpInExternalApiAdapter(IFilmFindByFilterLookUpInExternalApiFacade filmFindFromExternalAPIFacade,
            IFilmFindByFilterFindCategoryNameFacade filmFindCategoryFromCategoryName)
        {         
            _filmFindFromExternalAPIFacade = filmFindFromExternalAPIFacade;            
        }

        public Domain.FilmAggregate.Film LookUpInExternalApi(string name)
        {
            return _filmFindFromExternalAPIFacade.FindFilmInExternalAPI(name);
        }
    }
}
