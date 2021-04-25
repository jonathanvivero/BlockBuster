using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Application.UseCase.FindById
{
    public class CategoryFindByIdResponse : IResponse
    {
        public CategoryDTO Category { get; private set; }

        public CategoryFindByIdResponse(CategoryDTO category)
        {
            Category = category;
        }
    }
}
