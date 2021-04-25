using BlockBuster.FILM.Category.Domain.FilmAggregate;
using System;

namespace BlockBuster.FILM.Category.Infrastructure.Services.Factories
{
    public class CategoryFactory : ICategoryFactory
    {
        public Domain.FilmAggregate.Category Create(string id, 
            string name, 
            DateTime createdAt, 
            DateTime updatedAt)
        {
            var categoryId = new CategoryId(id);
            var categoryName = new CategoryName(name);
            var categoryCreatedAt = 
                new CategoryCreatedAt(createdAt);
            var categoryUpdatedAt = 
                new CategoryUpdatedAt(updatedAt);

            return Domain.FilmAggregate.Category.Create(
                categoryId, 
                categoryName, 
                categoryCreatedAt, 
                categoryUpdatedAt
            );
        }
    }
}
