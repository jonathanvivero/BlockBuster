using BlockBuster.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.FILM.Film.Application.UseCase.DispatchCorrectUseCase
{
    public class DispatchCorrectUseCaseResponse: IResponse
    {

        public IRequest ActualRequest { get; private set; }

        public DispatchCorrectUseCaseResponse(IRequest actualRequest)
        {
            ActualRequest = actualRequest;
        }
    }
}
