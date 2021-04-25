using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Category.Infrastructure.Services.Converters
{
    public class CategoryConverter
    {
        public CategoryDTO Convert(FilmCategory filmCategory)
        {
            return Convert(filmCategory.GetValue());
        }

        public CategoryDTO Convert(Domain.FilmAggregate.Category category)
        {
            return new CategoryDTO(
                category.Id.GetValue(),
                category.Name.GetValue(),
                category.CreatedAt.GetValue(),
                category.UpdatedAt.GetValue()
            );
        }
        public CategoryId Convert(FilmCategoryId categoryId)
        {
            return new CategoryId(categoryId.GetValue());
        }
    }

}