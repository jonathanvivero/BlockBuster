
using BlockBuster.IAM.Application.Converters.User;
using BlockBuster.IAM.Domain.UserAggregate.Factories;
using BlockBuster.IAM.Domain.UserAggregate.Repository;
using BlockBuster.IAM.Domain.UserAggregate.Validators;
using BlockBuster.IAM.Infrastructure.Services.User;
using BlockBuster.Shared.Application.Bus.UseCase;
using BlockBuster.Shared.Domain.Events;

namespace BlockBuster.IAM.Application.UseCases.User.SignUp
{
    public class UserSignUpUseCase : IUseCase
    {
        private readonly IUserFactory _userFactory;
        private readonly UserSignUpValidator _userSignUpValidator;
        private readonly IUserRepository _userRepository;
        private readonly UserConverter _userConverter;
        private readonly IEventProvider _eventProvider;
        private readonly UserAdapter _userAdapter;
        
        public UserSignUpUseCase(
            IUserFactory userFactory,
            UserSignUpValidator userSignUpValidator,
            IUserRepository userRepository,
            UserConverter userConverter,
            IEventProvider eventProvider,
            UserAdapter userAdapter)
        {
            _userFactory = userFactory;
            _userSignUpValidator = userSignUpValidator;
            _userRepository = userRepository;
            _userConverter = userConverter;
            _eventProvider = eventProvider;
            _userAdapter = userAdapter;
        }

        public IResponse Execute(IRequest req)
        {
            UserSignUpRequest request = req as UserSignUpRequest;

            var country = _userAdapter.FindCountryFromCountryCode(request.Country.Code);

            _userSignUpValidator.ValidateCountryExists(country, request.Country.Code);

            var user = _userFactory.Create(
                request.Id,
                request.Email,
                request.Password,
                request.RepeatPassword,
                request.FirstName,
                request.LastName,
                request.Role,
                country);


            _eventProvider.RecordEvents(user.ReleaseEvents());

            _userSignUpValidator.ValidateExistingUser(user.Email);

            _userRepository.Add(user);

            return _userConverter.Convert();
        }
    }
}
