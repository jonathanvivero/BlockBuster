using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.Shared.Infrastructure.Bus.Extensions
{
    public static class IRequestExtensions
    {
        public static string GetUseCaseName(this IRequest req)
        {
            string className = req.GetType().ToString();
            string[] words = className.Split(new string[] { UseCaseResources.RequestSufix }, StringSplitOptions.None);
            return words[0] + UseCaseResources.UseCaseSufix;
        }
    }
}
