using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public interface IFilmFindCategoryFromCategoryNameFacade
    {
        FilmCategory FindCountryFromCountryCode(string name);
    }
}