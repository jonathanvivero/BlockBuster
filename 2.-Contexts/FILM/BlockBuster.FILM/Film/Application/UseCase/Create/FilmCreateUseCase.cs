using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Infrastructure.Services.Film;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.Create
{
    public class FilmCreateUseCase : UseCaseBase
    {
        private readonly IFilmFactory _filmFactory;
        private readonly FilmConverter _filmConverter;
        private readonly IFilmAdapter _filmAdapter;
        private readonly IFilmRepository _filmRepository;
        private readonly IEventProvider _eventProvider;

        public FilmCreateUseCase(IFilmFactory filmFactory,
            FilmConverter filmConverter,
            IFilmRepository filmRepository,
            IEventProvider eventProvider,
            IFilmAdapter filmAdapter,
            IBlockBusterFilmContext context)
            :base(context)
        {
            _filmFactory = filmFactory;
            _filmConverter = filmConverter;
            _filmRepository = filmRepository;
            _eventProvider = eventProvider;
            _filmAdapter = filmAdapter;
        }
        public override IResponse Execute(IRequest req)
        {
            FilmCreateRequest request = req as FilmCreateRequest;

            FilmCategory category = _filmAdapter.FindCategoryFromCategoryName(request.Category.Name);

            var film = _filmFactory.Create(
                request.Id,
                request.Name,
                request.Description,
                category.GetValue().Id.GetValue(),
                category.GetValue());

            _eventProvider.RecordEvents(film.ReleaseEvents());

            _filmRepository.Add(film);

            return _filmConverter.Convert();
        }
    }
}
