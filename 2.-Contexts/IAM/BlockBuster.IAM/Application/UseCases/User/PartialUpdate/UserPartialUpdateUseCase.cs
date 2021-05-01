using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.PartialUpdate
{
    public class UserPartialUpdateUseCase : UseCaseBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserPartialUpdateUserValidator _userPartialUpdateUserIsAuthorizeValidator;
        private readonly UserFindByIdValidator _userFindByIdValidator;
        private readonly IUserFactory _userFactory;
        private readonly IEventProvider _eventProvider;
        private readonly UserConverter _userConverter;
        public UserPartialUpdateUseCase(
            IUserRepository userRepository,
            UserPartialUpdateUserValidator userPartialUpdateUserIsAuthorizeValidator,
            UserFindByIdValidator userFindByIdValidator,
            IUserFactory userFactory,
            IEventProvider eventProvider,
            UserConverter userConverter,
            IBlockBusterIAMContext context)
            :base(context)
        {
            _userRepository = userRepository;
            _userPartialUpdateUserIsAuthorizeValidator = userPartialUpdateUserIsAuthorizeValidator;
            _userFindByIdValidator = userFindByIdValidator;
            _userFactory = userFactory;
            _eventProvider = eventProvider;
            _userConverter = userConverter;
        }
        public override IResponse Execute(IRequest req)
        {
            UserPartialUpdateRequest request = req as UserPartialUpdateRequest;

            _userPartialUpdateUserIsAuthorizeValidator.ValidateContentNotEmpty(request.FirstName, request.LastName, request.Password);
            

            var userId = new UserId(request.Id);
            var user = _userRepository.FindUserById(userId);

            _userFindByIdValidator.Validate(user, userId);

            user = _userFactory.PartialUpdate(
                user,
                request.FirstName,
                request.LastName,
                request.Password);

            _eventProvider.RecordEvents(user.ReleaseEvents());

            _userRepository.Update(user);            

            return _userConverter.Convert();            
            
        }
    }
}
