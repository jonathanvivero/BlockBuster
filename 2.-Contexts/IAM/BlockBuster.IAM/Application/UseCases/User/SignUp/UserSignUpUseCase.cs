
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Application.UseCases.Email;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Domain.UserAggregate.ValueObjects;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Infrastructure.Persistence.Context;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.IAM.Application.UseCases.User.SignUp
{
    public class UserSignUpUseCase : UseCaseBase
    {
        private readonly IUserFactory _userFactory;
        private readonly UserSignUpEmailDoesNotExistValidator _userSignUpEmailDoesNotExistValidator;
        private readonly UserSignUpCountryExistsValidator _userSignUpCountryExistsValidator;
        private readonly IUserRepository _userRepository;
        private readonly UserConverter _userConverter;
        private readonly IEventProvider _eventProvider;
        private readonly UserAdapter _userAdapter;
        private readonly UserSendWelcomeEmailAdapter _userSendWelcomeEmailAdapter;
        
        public UserSignUpUseCase(
            IUserFactory userFactory,
            UserSignUpEmailDoesNotExistValidator userSignUpEmailDoesNotExistValidator,
            UserSignUpCountryExistsValidator userSignUpCountryExistsValidator,
            IUserRepository userRepository,
            UserConverter userConverter,
            IEventProvider eventProvider,
            UserAdapter userAdapter,
            UserSendWelcomeEmailAdapter userSendWelcomeEmailAdapter,
            IBlockBusterIAMContext context)
            : base(context)
        {
            _userFactory = userFactory;
            _userSignUpEmailDoesNotExistValidator = userSignUpEmailDoesNotExistValidator;
            _userRepository = userRepository;
            _userConverter = userConverter;
            _eventProvider = eventProvider;
            _userAdapter = userAdapter;
            _userSendWelcomeEmailAdapter = userSendWelcomeEmailAdapter;
        }

        public override IResponse Execute(IRequest req)
        {
            UserSignUpRequest request = req as UserSignUpRequest;
            
            _userSignUpEmailDoesNotExistValidator.Validate(request.Email);

            UserCountry country = _userAdapter.FindCountryFromCountryCode(request.Country.Code);
            _userSignUpCountryExistsValidator.Validate(country, request.Country.Code);

            var user = _userFactory.Create(
                request.Id,
                request.Email,
                request.Password,
                request.RepeatPassword,
                request.FirstName,
                request.LastName,
                request.Role,
                country.GetValue().Id.GetValue(), 
                country.GetValue());


            _eventProvider.RecordEvents(user.ReleaseEvents());

            _userRepository.Add(user);

            _userSendWelcomeEmailAdapter.SendUserSignedUpWelcomeEmail(user);

            return _userConverter.Convert();
        }
    }
}
