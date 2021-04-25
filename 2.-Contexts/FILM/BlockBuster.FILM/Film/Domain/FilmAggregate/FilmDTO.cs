using BlockBuster.FILM.Category.Domain.FilmAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class FilmDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public FilmDTO(string id, string name, string description, string categoryId, CategoryDTO category, DateTime createdAt, DateTime updatedAt)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.CategoryId = categoryId;
            this.Category = category;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
    }
}
