using BlockBuster.FILM.Category.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Application.UseCase.Create;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Infrastructure.Services.Film;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.LookUpFilmInExternalApi
{
    public class LookUpFilmInExternalApiUseCase: UseCaseBase
    {
        private readonly FilmConverter _filmConverter;
        private readonly IFilmFindByFilterLookUpInExternalApiAdapter _filmFindByFilterLookUpInExternalApiAdapter;
        private readonly CategoryConverter _categoryConverter;
        private readonly IUseCaseBus _useCaseBus;

        public LookUpFilmInExternalApiUseCase(
            FilmConverter filmConverter,
            CategoryConverter categoryConverter,
            IUseCaseBus useCaseBus,
            IFilmFindByFilterLookUpInExternalApiAdapter filmFindByFilterLookUpInExternalApiAdapter,
            IBlockBusterFilmContext context)
            : base(context)
        {
            _filmFindByFilterLookUpInExternalApiAdapter = filmFindByFilterLookUpInExternalApiAdapter;
            _filmConverter = filmConverter;
            _categoryConverter = categoryConverter;
            _useCaseBus = useCaseBus;
        }

        public override IResponse Execute(IRequest req)
        {
            LookUpFilmInExternalApiRequest request = req as LookUpFilmInExternalApiRequest;

            if (request.Film != null)
                return _filmConverter.ConvertToLookUpFilmInExternalApiResponse(request.Film);

            var filmResponse = _filmConverter.ConvertToLookUpFilmInExternalApiResponse(                
                _filmFindByFilterLookUpInExternalApiAdapter.LookUpInExternalApi(request.Name)
            );

            var film = filmResponse.Film;
            FilmCreateRequest filmCreateRequest =
                new FilmCreateRequest(film.Id.GetValue(), 
                film.Name.GetValue(),
                film.Description.GetValue(),
                _categoryConverter.Convert(film.Category));

            return _useCaseBus.Dispatch(filmCreateRequest);
        }
    }
}
