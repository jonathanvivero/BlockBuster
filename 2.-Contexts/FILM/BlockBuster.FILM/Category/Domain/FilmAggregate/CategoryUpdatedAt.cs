using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate
{
    public class CategoryUpdatedAt: DateTimeValueObject
    {
        public CategoryUpdatedAt(DateTime value) : base(value)
        {

        }
    }
}
