using BlockBuster.IAM.Application.UseCases.User.GetUsers;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster.IAM.Application.Converters.User
{
    public class UserGetUsersConverter
    {
        private readonly IUserTranslator _userTranslator;
        public UserGetUsersConverter(IUserTranslator userTranslator)
        {
            _userTranslator = userTranslator;
        }
        public IResponse Convert(IEnumerable<Domain.UserAggregate.User> users)
        {            
            var userDTOs = users
                .Select(s => new UserDTO(
                    _(s.Id),
                    _(s.Email),
                    _(s.FirstName),
                    _(s.LastName),
                    _(s.Role),
                    _(s.CreatedAt),
                    _(s.UpdatedAt),
                    _(s.CountryId),
                    _userTranslator.FromUserCountryToCountryDTO(_(s.Country))
                    )
                )
                .ToArray();
            return new UserGetUsersResponse(userDTOs);
        }

        private T _<T>(ValueObject<T> vo)
            => vo.GetValue();
    }

}
