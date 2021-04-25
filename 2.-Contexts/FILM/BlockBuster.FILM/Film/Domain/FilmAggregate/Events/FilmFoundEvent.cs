﻿using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Domain.FilmAggregate.Events
{
    public class FilmFoundEvent : DomainEvent
    {
        public FilmFoundEvent(
            string aggregatId,
            DomainEventBody body)
            : base(aggregatId, body, FilmResources.ResourceManager) { }

        protected override DomainEventRules Rules()
            => new FilmFoundEventRules(Name());
    }
}
