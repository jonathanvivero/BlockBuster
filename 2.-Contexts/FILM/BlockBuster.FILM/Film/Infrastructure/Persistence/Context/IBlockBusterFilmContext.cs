using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.FILM.Category.Domain.FilmAggregate;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.FILM.Film.Infrastructure.Persistence.Context
{
    public interface IBlockBusterFilmContext: IBlockBusterContext
    {
        DbSet<Domain.FilmAggregate.Film> Films { get; set; }
        DbSet<Category.Domain.FilmAggregate.Category> Categories { get; set; }
    }
}
