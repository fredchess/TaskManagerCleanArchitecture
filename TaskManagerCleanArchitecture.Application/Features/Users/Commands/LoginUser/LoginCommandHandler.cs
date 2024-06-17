using AutoMapper;
using MediatR;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application.Contracts.Persistence;
using TaskManagerCleanArchitecture.Application.Exceptions;
using TaskManagerCleanArchitecture.Domain.Entities;

namespace TaskManagerCleanArchitecture.Application.Features.Users.Commands.LoginUser
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var creds = _mapper.Map<ApplicationUser>(request);

            if (!await _userRepository.ValidateCredentials(request)) {
                throw new InvalidCredentialsException("");
            }

            return _jwtProvider.GenerateToken(_mapper.Map<ApplicationUser>(request));
        }
    }
}