using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Category.Infrastructure.Services;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.Shared.Application.Bus.UseCase;

namespace BlockBuster.FILM.Film.Application.UseCase.GetAll
{
    public class FilmGetFilmsUseCase : UseCaseBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryTranslator _categoryTranslator;
        private readonly FilmConverter _filmConverter;
        private readonly FilmCategoryBinderFacade _filmCategoryBinderFacade;
        public FilmGetFilmsUseCase(IFilmRepository filmRepository,
            ICategoryRepository categoryRepository,
            FilmConverter filmConverter,
            ICategoryTranslator categoryTranslator,
            FilmCategoryBinderFacade filmCategoryBinderFacade,
            IBlockBusterFilmContext context)
            :base(context)
        {
            _filmRepository = filmRepository;
            _categoryRepository = categoryRepository;
            _filmConverter = filmConverter;
            _filmCategoryBinderFacade = filmCategoryBinderFacade;
            _categoryTranslator = categoryTranslator;
        }

        public override IResponse Execute(IRequest req)
        {
            FilmGetFilmsRequest request = req as FilmGetFilmsRequest;

            var categoryDict = _categoryTranslator
                .ToCategoryDictionary(
                    _categoryRepository.GetAllCategories()
                );

            var filmList = _filmCategoryBinderFacade
                .Bind(
                    _filmRepository.GetAllFilms(request.Page),
                    categoryDict
                );

            FilmGetFilmsResponse response = new FilmGetFilmsResponse(
                _filmConverter.Convert(filmList)
                );

            return response;
        }
    }
}
