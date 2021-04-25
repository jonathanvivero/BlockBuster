using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate
{
    public class CategoryId: UUIDValueObject
    {
        public CategoryId(string value) : base(value)        {

        }
    }
}
