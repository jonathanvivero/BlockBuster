using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Category.Infrastructure.Services;
using BlockBuster.FILM.Category.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Application.UseCase.GetAll;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.FindById
{
    public class FilmFindByIdUseCase : UseCaseBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryTranslator _categoryTranslator;
        private readonly FilmConverter _filmConverter;
        private readonly FilmCategoryBinderFacade _filmCategoryBinderFacade;
        private readonly CategoryConverter _categoryConverter;
        public FilmFindByIdUseCase(IFilmRepository filmRepository,
            ICategoryRepository categoryRepository,
            FilmConverter filmConverter,
            CategoryConverter categoryConverter,
            CategoryTranslator categoryTranslator,
            FilmCategoryBinderFacade filmCategoryBinderFacade,
            IBlockBusterFilmContext context)
            : base(context)
        {
            _filmRepository = filmRepository;
            _categoryRepository = categoryRepository;
            _filmConverter = filmConverter;
            _categoryConverter = categoryConverter;
            _filmCategoryBinderFacade = filmCategoryBinderFacade;
            _categoryTranslator = categoryTranslator;
        }

        public override IResponse Execute(IRequest req)
        {
            FilmFindByIdRequest request = req as FilmFindByIdRequest;

            var categoryDict = _categoryTranslator
                .ToCategoryDictionary(
                    _categoryRepository.GetAllCategories()
                );
            var filmId = new FilmId(request.Id);
            var film = _filmRepository.FindById(filmId);
            var cagegoryId = _categoryConverter.Convert(film.CategoryId);
            var category = _categoryRepository.FindById(cagegoryId);
            film.SetCategory(new FilmCategory(category));

            FilmFindByIdResponse response = new FilmFindByIdResponse(
                _filmConverter.Convert(film)
                );

            return response;
        }
    }
}
