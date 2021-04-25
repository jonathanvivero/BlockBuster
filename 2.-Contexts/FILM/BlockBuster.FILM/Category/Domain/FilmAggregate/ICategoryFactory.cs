using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate
{
    public interface ICategoryFactory
    {
        Category Create(
          string id,
          string name,          
          DateTime createdAt,
          DateTime updatedAt
          );
    }
}
