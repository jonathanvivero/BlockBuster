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

namespace BlockBuster.FILM.Film.Application.UseCase.FindByName
{
    public class FilmFindByNameUseCase: UseCaseBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryTranslator _categoryTranslator;
        private readonly FilmConverter _filmConverter;
        private readonly FilmCategoryBinderFacade _filmCategoryBinderFacade;
        private readonly CategoryConverter _categoryConverter;
        public FilmFindByNameUseCase(IFilmRepository filmRepository,
            ICategoryRepository categoryRepository,
            FilmConverter filmConverter,
            CategoryConverter categoryConverter,
            ICategoryTranslator categoryTranslator,
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
            FilmFindByNameRequest request = req as FilmFindByNameRequest;

            var categoryDict = _categoryTranslator
                .ToCategoryDictionary(
                    _categoryRepository.GetAllCategories()
                );
            var filmName = new FilmName(request.Name);
            var film = _filmRepository.FindByName(filmName);
            var cagegoryId = _categoryConverter.Convert(film.CategoryId);
            var category = _categoryRepository.FindById(cagegoryId);
            film.SetCategory(new FilmCategory(category));

            FilmFindByNameResponse response = new FilmFindByNameResponse(
                _filmConverter.Convert(film)
                );

            return response;
        }
    }
}
