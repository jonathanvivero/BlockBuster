using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public class FilmTranslator: IFilmTranslator
    {
        public FilmCategory Translate(Category.Domain.FilmAggregate.Category category)
        {
            return new FilmCategory(category);
        }
    }
}