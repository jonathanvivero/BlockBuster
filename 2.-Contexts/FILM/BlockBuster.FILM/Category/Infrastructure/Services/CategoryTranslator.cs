using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BlockBuster.FILM.Category.Domain.FilmAggregate;

namespace BlockBuster.FILM.Category.Infrastructure.Services
{
    public class CategoryTranslator: ICategoryTranslator
    {
        public IDictionary<string, Domain.FilmAggregate.Category> ToCategoryDictionary(IEnumerable<Domain.FilmAggregate.Category> categoryList)
        {
            var dict = categoryList.ToDictionary(k => k.Id.GetValue(), v => v);
            return dict;
        }

        public IDictionary<string, CategoryDTO> ToCategoryDictionary(IEnumerable<CategoryDTO> categoryList)
        {
            var dict = categoryList.ToDictionary(k => k.Id, v => v);
            return dict;
        }
    }
}
