using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public interface IFilmTranslator
    {
        FilmCategory Translate(Category.Domain.FilmAggregate.Category category);
    }
}