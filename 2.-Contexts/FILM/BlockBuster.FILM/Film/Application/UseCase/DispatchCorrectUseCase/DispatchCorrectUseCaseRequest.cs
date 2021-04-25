using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.DispatchCorrectUseCase
{
    public class DispatchCorrectUseCaseRequest : AbstractRequest
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public IQueryCollection Query { get; private set; }

        public DispatchCorrectUseCaseRequest(IQueryCollection query) : base(query)
        {
            Query = query;
            this.QueryId();
            this.QueryName();
        }

        private void QueryId()
            => Id = Query[FilmResources.QueryFieldId];

        private void QueryName()
            => Name = Query[FilmResources.QueryFieldName];        
    }
}
