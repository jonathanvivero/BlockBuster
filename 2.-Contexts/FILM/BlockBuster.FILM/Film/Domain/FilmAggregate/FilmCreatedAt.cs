using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class FilmCreatedAt: DateTimeValueObject
    {
        public FilmCreatedAt(DateTime value) : base(value)
        {

        }
    }
}
