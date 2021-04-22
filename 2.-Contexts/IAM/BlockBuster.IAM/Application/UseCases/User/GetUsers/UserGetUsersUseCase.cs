using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.GetUsers
{
    public class UserGetUsersUseCase : UseCaseBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserGetUsersConverter _userGetUsersConverter;
        
        public UserGetUsersUseCase(
            IUserRepository userRepository,
            UserGetUsersConverter userGetUsersConverter,
            IBlockBusterIAMContext context)
            :base(context)
        {
            _userRepository = userRepository;
            _userGetUsersConverter = userGetUsersConverter;

        }
        public override IResponse Execute(IRequest req)
        {
            UserGetUsersRequest request = req as UserGetUsersRequest;
            var userList = _userRepository.GetUsers(request.Page());
            return _userGetUsersConverter.Convert(userList);
        }
    }
}
