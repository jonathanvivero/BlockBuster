using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BlockBuster.FILM.Category.Domain.FilmAggregate;

namespace BlockBuster.FILM.Category.Infrastructure.Services
{
    public interface ICategoryTranslator
    {
        IDictionary<string, Domain.FilmAggregate.Category> ToCategoryDictionary(IEnumerable<Domain.FilmAggregate.Category> categoryList);
        IDictionary<string, CategoryDTO> ToCategoryDictionary(IEnumerable<CategoryDTO> categoryList);
    }
}
