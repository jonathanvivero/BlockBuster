using BlockBuster.FILM.Category.Infrastructure.Services.Converters;
using BlockBuster.FILM.Film.Application.UseCase.Create;
using BlockBuster.FILM.Film.Application.UseCase.DispatchCorrectUseCase;
using BlockBuster.FILM.Film.Application.UseCase.FindById;
using BlockBuster.FILM.Film.Application.UseCase.FindByName;
using BlockBuster.FILM.Film.Application.UseCase.GetAll;
using BlockBuster.FILM.Film.Application.UseCase.LookUpFilmInExternalApi;
using BlockBuster.FILM.Film.Domain.FilmAggregate;
using BlockBuster.Shared.Application.Bus.UseCase;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.FILM.Film.Infrastructure.Services.Converters
{
    public class FilmConverter
    {
        private readonly CategoryConverter _categoryConverter;
        public FilmConverter(CategoryConverter categoryConverter)
        {
            _categoryConverter = categoryConverter;
        }

        public IEnumerable<FilmDTO> Convert(IEnumerable<Domain.FilmAggregate.Film> filmList)
        {
            return filmList
                .Select(s => Convert(s));
        }

        public FilmDTO Convert(Domain.FilmAggregate.Film film)
        {
            return new FilmDTO(
                film.Id.GetValue(),
                film.Name.GetValue(),
                film.Description.GetValue(),
                film.CategoryId.GetValue(),
                _categoryConverter.Convert(film.Category),
                film.CreatedAt.GetValue(),
                film.UpdatedAt.GetValue()

            );
            //_categoryConverter.Convert(film.Category),
        }

        public FilmCreateResponse Convert()
        {
            return new FilmCreateResponse();
        }

        public DispatchCorrectUseCaseResponse ToFilmFindByIdRequest(IQueryCollection query)
        {
            return new DispatchCorrectUseCaseResponse(
                new FilmFindByIdRequest(query)
            );
        }

        public DispatchCorrectUseCaseResponse ToFilmFindByNameRequest(IQueryCollection query)
        {
            return new DispatchCorrectUseCaseResponse(
                new FilmFindByNameRequest(query));
        }

        public DispatchCorrectUseCaseResponse ToFilmGetAllRequest(IQueryCollection query)
        {
            return new DispatchCorrectUseCaseResponse(
                new FilmGetFilmsRequest(query));    
        }

        public LookUpFilmInExternalApiResponse ConvertToLookUpFilmInExternalApiResponse(Domain.FilmAggregate.Film film)
        {
            return new LookUpFilmInExternalApiResponse(film);
        }
    }
}
