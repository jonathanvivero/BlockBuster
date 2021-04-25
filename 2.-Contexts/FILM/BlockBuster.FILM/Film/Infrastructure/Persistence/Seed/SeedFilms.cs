using BlockBuster.FILM.Category.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Persistence.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Persistence.Seed
{
    public class SeedFilms : SeedChannel<IBlockBusterFilmContext>
    {
        private IFilmFactory _filmFactory;
        private ICategoryFactory _categoryFactory;
        public SeedFilms(IBlockBusterFilmContext context,
            IFilmFactory filmFactory,
            ICategoryFactory categoryFactory)
            : base(context)
        {
            _filmFactory = filmFactory;
            _categoryFactory = categoryFactory;
        }

        public override void SeedDatabase()
        {
            if (!_context.Categories.Any())
            {
                var countries = ListOfCategories();

                _context.Categories.AddRange(countries);
                _context.SaveChanges();
            }

        }

        private IList<Category.Domain.FilmAggregate.Category> ListOfCategories()
        {
            return new List<Category.Domain.FilmAggregate.Category>()
            {
                _categoryFactory.Create(
                    "032ca58c-26e9-41de-a539-3a30a51177ac",
                    "Drama",
                    DateTime.Now,
                    DateTime.Now),
                _categoryFactory.Create(
                    "24c554a4-68a8-49b0-b1c4-02054fe113bc",
                    "Comedy",
                    DateTime.Now,
                    DateTime.Now),
                _categoryFactory.Create(
                    "8ae83972-fdb8-4a71-84be-b59e4086f99a",
                    "Terror",
                    DateTime.Now,
                    DateTime.Now),
                _categoryFactory.Create(
                    "99f5d729-b0a3-4b03-b139-60c61cd75c28",
                    "Musical",
                    DateTime.Now,
                    DateTime.Now),
                _categoryFactory.Create(
                    "ad42ee53-2429-401a-a522-fe54b6a1c932",
                    "BioPic",
                    DateTime.Now,
                    DateTime.Now)
            };
        }
    }
}
