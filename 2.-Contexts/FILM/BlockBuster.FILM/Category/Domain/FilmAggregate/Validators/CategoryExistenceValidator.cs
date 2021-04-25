using BlockBuster.FILM.Category.Domain.FilmAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate.Validators
{
    public class CategoryExistenceValidator
    {
        public void Validate(Category category, string name)
        {
            if (category == null)
                throw CategoryNotFoundException.FromFindByIdNotFound(name);
        }
    }
}
