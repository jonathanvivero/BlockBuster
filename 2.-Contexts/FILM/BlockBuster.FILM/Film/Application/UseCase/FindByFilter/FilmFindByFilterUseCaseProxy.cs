using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Infrastructure.Services.Film;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindByFilter
{
    
    public class FilmFindByFilterUseCaseProxy : FilmFindByFilterUseCase
    {
        private readonly IFilmFindByFilterLookUpInExternalApiAdapter _filmFindByFilterLookUpInExternalApiAdapter;

        public FilmFindByFilterUseCaseProxy(IFilmRepository filmRepository,
            FilmConverter filmConverter,
            IFilmFindByFilterLookUpInExternalApiAdapter filmFindByFilterLookUpInExternalApiAdapter,
            IBlockBusterFilmContext context)
            : base(filmRepository, filmConverter, context)
        {
            _filmFindByFilterLookUpInExternalApiAdapter = filmFindByFilterLookUpInExternalApiAdapter;
        }

        public override IResponse Execute(IRequest req)
        {
            FilmFindByFilterRequest request = req as FilmFindByFilterRequest;
            FilmFindByFilterResponse response = base.Execute(req) as FilmFindByFilterResponse;

            if (!response.Films.Any()
                && request.Filter.ContainsKey(FilmResources.FieldName)
                && request.Filter.Keys.Count == 1) 
            {
                foreach(var name in request.Filter[FilmResources.FieldName])                
                    _filmFindByFilterLookUpInExternalApiAdapter.LookUpInExternalApi(name);

                response = base.Execute(req) as FilmFindByFilterResponse;
            }

            return response;
        }
    }
}
