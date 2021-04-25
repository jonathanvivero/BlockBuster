using BlockBuster.FILM.Category.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate.Exceptions
{
    public class CategoryNotFoundException: ValidationException
    {
        public CategoryNotFoundException(string message)
            : base(message)
        {

        }

        public static CategoryNotFoundException FromFindByIdNotFound(string name) 
        {
            return new CategoryNotFoundException(
                string.Format(
                    CategoryResurces.ValidationCategoryNotFound,
                    name
                )
            );

        }

    }
}
