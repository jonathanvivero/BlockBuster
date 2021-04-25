using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Domain.FilmAggregate
{
    public class Category
    {
        public CategoryId Id { get; private set; }
        public CategoryName Name { get; private set; }        
        public CategoryCreatedAt CreatedAt { get; private set; }
        public CategoryUpdatedAt UpdatedAt { get; private set; }

        public Category()
        {

        }

        private Category(CategoryId categoryId, 
            CategoryName categoryName, 
            CategoryCreatedAt categoryCreatedAt, 
            CategoryUpdatedAt categoryUpdatedAt)
        {
            Id = categoryId;
            Name = categoryName;
            CreatedAt = categoryCreatedAt;
            UpdatedAt = categoryUpdatedAt;
        }

        public static Category Create(CategoryId categoryId,
            CategoryName categoryName,
            CategoryCreatedAt categoryCreatedAt,
            CategoryUpdatedAt categoryUpdatedAt)
        { 
            var category = new Category(categoryId, 
                categoryName, 
                categoryCreatedAt, 
                categoryUpdatedAt);
            
            return category;
        }

    }
}
