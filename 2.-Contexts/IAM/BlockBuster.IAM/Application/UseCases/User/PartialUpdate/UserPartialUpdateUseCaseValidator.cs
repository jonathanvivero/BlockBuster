using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Infrastructure.Security.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockBuster.IAM.Application.UseCases.User.PartialUpdate
{
    public class UserPartialUpdateUseCaseValidator : IUseCaseValidator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserPartialUpdateUserValidator _userPartialUpdateUserIsAuthorizeValidator;
        public UserPartialUpdateUseCaseValidator(
            UserPartialUpdateUserValidator userPartialUpdateUserIsAuthorizeValidator,
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _userPartialUpdateUserIsAuthorizeValidator = userPartialUpdateUserIsAuthorizeValidator;
        }
        public IResponse Validate(IRequest req)
        {
            UserPartialUpdateRequest request = req as UserPartialUpdateRequest;

            var userId = _authenticationService.GetNameIdentifier();
            
            _userPartialUpdateUserIsAuthorizeValidator.ValidateUserIsAuthorized(userId, request.Id);
            
            return null;
        }
    }
}
