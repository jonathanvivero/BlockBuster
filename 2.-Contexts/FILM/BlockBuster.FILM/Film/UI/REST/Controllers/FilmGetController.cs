using BlockBuster.FILM.Film.Application.UseCase.DispatchCorrectUseCase;
using BlockBuster.FILM.Film.Application.UseCase.FindByFilter;
using BlockBuster.FILM.Film.Application.UseCase.GetAll;
using BlockBuster.FILM.Film.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.UI.REST.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Country.UI.REST.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/films")]
    [ApiController]
    public class FilmGetController : BaseRESTController
    {
        public FilmGetController(
            IUseCaseBus useCaseBus,
            IBlockBusterFilmContext context)
           : base(useCaseBus) { }

        [Authorize(Roles = "User")]
        [HttpGet(Name = nameof(GetFilms))]
        public IActionResult GetFilms()
        {
            FilmFindByFilterRequest request = new FilmFindByFilterRequest(HttpContext.Request.Query);

            return Dispatch(request);
        }
    }
}
