using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate.Events
{
    public class FilmFoundEventBody: DomainEventBody
    {
        public FilmFoundEventBody(Domain.FilmAggregate.Film entity)
        {
            Add(FilmResources.FieldId, entity.Id);
            Add(FilmResources.FieldName, entity.Name);
            Add(FilmResources.FieldDescription, entity.Description);
            Add(FilmResources.FieldCategoryId, entity.CategoryId);
            Add(FilmResources.FieldCategoryName, entity.Category.GetValue().Name);
        }
    }
}
