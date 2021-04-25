using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class FilmCategoryId: UUIDValueObject
    {
        public FilmCategoryId(string value) : base(value)

        {

        }
    }
}
