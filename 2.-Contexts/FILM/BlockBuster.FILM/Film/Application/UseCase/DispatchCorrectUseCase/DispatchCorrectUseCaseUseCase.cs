using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;

namespace BlockBuster.FILM.Film.Application.UseCase.DispatchCorrectUseCase
{
    public class DispatchCorrectUseCaseUseCase: UseCaseBase
    {
        private readonly FilmConverter _filmConverter;
        private readonly IUseCaseBus _useCaseBus;
        public DispatchCorrectUseCaseUseCase(
            IUseCaseBus useCaseBus,
            FilmConverter filmConverter, 
            IBlockBusterFilmContext context)
            :base(context)
        {
            _filmConverter = filmConverter;
            _useCaseBus = useCaseBus;
        }

        public override IResponse Execute(IRequest req)
        {
            DispatchCorrectUseCaseRequest request = req as DispatchCorrectUseCaseRequest;
            DispatchCorrectUseCaseResponse response;

            if (string.IsNullOrEmpty(request.Id))
            { 
                response = _filmConverter.ToFilmFindByIdRequest(request.Query);
                return _useCaseBus.Dispatch(response.ActualRequest);                
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                response = _filmConverter.ToFilmFindByNameRequest(request.Query);
                return _useCaseBus.Dispatch(response.ActualRequest);
            }
            
            response = _filmConverter.ToFilmGetAllRequest(request.Query);
            return _useCaseBus.Dispatch(response.ActualRequest);
            
        }
    }
}
