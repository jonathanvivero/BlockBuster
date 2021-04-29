using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Security.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.GetUsers
{
    public class UserGetUsersUseCase : UseCaseBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAdapter _userAdapter;
        private readonly UserGetUsersConverter _userGetUsersConverter;
        private readonly IAuthenticationService _authenticationService;
        public UserGetUsersUseCase(
            IUserRepository userRepository,
            IUserAdapter userAdapter,
            UserGetUsersConverter userGetUsersConverter,
            IAuthenticationService authenticationService,
            IBlockBusterIAMContext context)
            :base(context)
        {
            _userRepository = userRepository;
            _userAdapter = userAdapter;
            _userGetUsersConverter = userGetUsersConverter;
            _authenticationService = authenticationService;
        }
        public override IResponse Execute(IRequest req)
        {
            Console.WriteLine(_authenticationService.Get());
            UserGetUsersRequest request = req as UserGetUsersRequest;
            var userList = _userRepository.GetUsers(request.Page);
            var countries = _userAdapter.GetUserCountries();
            return _userGetUsersConverter.Convert(userList, countries);
        }
    }
}
