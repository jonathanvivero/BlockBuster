using BlockBuster.FILM.Film.Domain.FilmAggregate.Events;
using BlockBuster.Shared.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate
{
    public class Film : AggregateRoot
    {
        public FilmId Id { get; private set; }
        public FilmName Name { get; private set; }
        public FilmDescription Description { get; private set; }
        public FilmCategoryId CategoryId { get; private set; }
        public FilmCategory Category { get; private set; }
        public FilmCreatedAt CreatedAt { get; private set; }
        public FilmUpdatedAt UpdatedAt { get; private set; }
        public Film()
        {

        }

        private Film(FilmId id,
            FilmName name,
            FilmDescription description,
            FilmCategoryId categoryId,
            FilmCategory category,
            FilmCreatedAt createdAt,
            FilmUpdatedAt updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Category = category;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Film Create(FilmId id,
            FilmName name,
            FilmDescription description,
            FilmCategoryId categoryId,
            FilmCategory category,
            FilmCreatedAt createdAt,
            FilmUpdatedAt updatedAt) 
        {
            var film = new Film(id, 
                name, 
                description, 
                categoryId, 
                category, 
                createdAt, 
                updatedAt);

            film.Record(
                new FilmCreatedEvent(
                    film.Id.GetValue(),
                    new FilmCreatedEventBody(film)
                )
            );

            return film;


        }

        public void SetCategory(FilmCategory filmCategory)
        {
            this.Category = filmCategory;
        }
    }
}
