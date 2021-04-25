using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class FilmName: StringValueObject
    {
        public FilmName(string value) : base(value) { }
    }
}
