using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Category.Domain.FilmAggregate.Validators;
using BlockBuster.FILM.Film.Domain.FilmAggregate;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public class FilmFindByFilterFindCategoryNameFacade : IFilmFindByFilterFindCategoryNameFacade
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilmTranslator _filmTranslator;
        private readonly CategoryExistenceValidator _categoryExistenceValidator;
        public FilmFindByFilterFindCategoryNameFacade (
            ICategoryRepository categoryRepository,
            IFilmTranslator filmTranslator,
            CategoryExistenceValidator categoryExistenceValidator)
        {
            _categoryRepository = categoryRepository;
            _filmTranslator = filmTranslator;
            _categoryExistenceValidator = categoryExistenceValidator;
        }

        public FilmCategory FindCategoryFromCategoryName(string name)
        {
            var categoryName = new CategoryName(name);
            var category = _categoryRepository.FindByName(categoryName);
            
            _categoryExistenceValidator.Validate(category, name);
            
            var filmCategory = _filmTranslator.Translate(category);

            return filmCategory;
        }        
    }
}