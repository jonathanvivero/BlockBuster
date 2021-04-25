using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;
using BlockBuster.Shared.Infrastructure.Resources;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate.Events
{
    internal class FilmFoundEventRules : DomainEventRules
    {
        public FilmFoundEventRules(string name) : base(name)
        {
            Add(FilmResources.FieldId, DataTypeResources.STRING);
            Add(FilmResources.FieldName, DataTypeResources.STRING);
            Add(FilmResources.FieldDescription, DataTypeResources.DOUBLE);
            Add(FilmResources.FieldCategoryId, DataTypeResources.STRING);
            Add(FilmResources.FieldCategoryName, DataTypeResources.STRING);
        }
    }
}