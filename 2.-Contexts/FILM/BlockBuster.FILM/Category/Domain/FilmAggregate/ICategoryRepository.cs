using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate
{
    public interface ICategoryRepository
    {
        Category FindById(CategoryId id);
        Category FindByName(CategoryName name);
        IEnumerable<Category> GetAllCategories();
    }
}
