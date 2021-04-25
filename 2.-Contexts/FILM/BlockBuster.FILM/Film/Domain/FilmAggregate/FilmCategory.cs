using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class FilmCategory: ValueObject<Category.Domain.FilmAggregate.Category>
    {
        public FilmCategory(Category.Domain.FilmAggregate.Category value)
            :base(value)
        {

        }
    }
}
