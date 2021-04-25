using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Application.UseCase.FindById
{
    public class CategoryFindByIdRequest: IRequest 
    {
        public string Id { get; private set; }
        public CategoryFindByIdRequest(string id)
        {
            Id = id;
        }
    }
}
