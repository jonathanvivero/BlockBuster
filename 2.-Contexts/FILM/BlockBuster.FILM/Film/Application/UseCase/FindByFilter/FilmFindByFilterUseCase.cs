using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Resources;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindByFilter
{
    public class FilmFindByFilterUseCase : UseCaseBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly FilmConverter _filmConverter;

        public FilmFindByFilterUseCase(IFilmRepository filmRepository,
            FilmConverter filmConverter,
            IBlockBusterFilmContext context)
            : base(context)
        {
            _filmRepository = filmRepository;
            _filmConverter = filmConverter;
        }
        public override IResponse Execute(IRequest req)
        {
            FilmFindByFilterRequest request = req as FilmFindByFilterRequest;

            var filmList = _filmRepository.GetAllFilms(request.Page, request.Filter);            

            return new FilmFindByFilterResponse(
                _filmConverter.Convert(filmList)
            );

        }
    }
}
