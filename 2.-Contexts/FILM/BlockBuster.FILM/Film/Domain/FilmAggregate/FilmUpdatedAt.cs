using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class FilmUpdatedAt: DateTimeValueObject
    {
        public FilmUpdatedAt(DateTime value)
            :base(value) { }
    }
}
