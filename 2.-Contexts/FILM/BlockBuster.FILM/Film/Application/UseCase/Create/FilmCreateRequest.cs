using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.Create
{
    public class FilmCreateRequest : IRequest
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CategoryDTO Category { get; private set; }

        public FilmCreateRequest(string id, string name, string description, CategoryDTO category)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
        }

    }
}
