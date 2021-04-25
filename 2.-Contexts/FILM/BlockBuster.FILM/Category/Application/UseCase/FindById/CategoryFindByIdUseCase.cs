using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Film.Infrastructure.Services.Converters;
using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Category.Application.UseCase.FindById
{
    public class CategoryFindByIdUseCase : UseCaseBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryConverter _categoryConverter;
        public CategoryFindByIdUseCase(
            ICategoryRepository categoryRepository,
            CategoryConverter categoryConverter,
            IBlockBusterFilmContext context)
            :base(context)
        {
            _categoryRepository = categoryRepository;
            _categoryConverter = categoryConverter;
        }
        public override IResponse Execute(IRequest req)
        {
            CategoryFindByIdRequest request = req as CategoryFindByIdRequest;
            var categoryId = new CategoryId(request.Id);
            var category = _categoryRepository.FindById(categoryId);
            return new CategoryFindByIdResponse(
                _categoryConverter.Convert(category)
                );
        }
    }
}
