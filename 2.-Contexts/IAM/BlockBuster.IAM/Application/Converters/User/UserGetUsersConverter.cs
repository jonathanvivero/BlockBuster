using BlockBuster.IAM.Application.UseCases.User.GetUsers;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
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
        public IResponse Convert(IEnumerable<Domain.UserAggregate.User> users, IEnumerable<UserCountry> userCountryList)
        {            
            var userDTOs = users
                .Select(s => new UserDTO(
                    s.Id.GetValue(),
                    s.Email.GetValue(),
                    s.FirstName.GetValue(),
                    s.LastName.GetValue(),
                    s.Role.GetValue(),
                    s.CreatedAt.GetValue(),
                    s.UpdatedAt.GetValue(),
                    s.CountryId.GetValue(),
                    _userTranslator.FromUserCountryToCountryDTO(
                        userCountryList
                            .FirstOrDefault(w => w.GetValue().Id.GetValue() == s.CountryId.GetValue())
                            .GetValue()
                        )
                    )
                )
                .ToArray();
            return new UserGetUsersResponse(userDTOs);
        }

        private T _<T>(ValueObject<T> vo)
            => vo.GetValue();
    }

}
