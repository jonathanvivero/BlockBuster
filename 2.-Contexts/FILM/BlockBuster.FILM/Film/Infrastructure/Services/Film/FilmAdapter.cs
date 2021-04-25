using BlockBuster.FILM.Film.Domain.FilmAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Film
{
    public class FilmAdapter: IFilmAdapter
    {
        private readonly IFilmFindCategoryFromCategoryNameFacade _filmFindCategoryFromCategoryName;
        public FilmAdapter(IFilmFindCategoryFromCategoryNameFacade filmFindCategoryFromCategoryName)
        {
            _filmFindCategoryFromCategoryName = filmFindCategoryFromCategoryName;
        }

        public FilmCategory FindCategoryFromCategoryName(string name)
        {
            return _filmFindCategoryFromCategoryName.FindCountryFromCountryCode(name);
        }

    }
}
