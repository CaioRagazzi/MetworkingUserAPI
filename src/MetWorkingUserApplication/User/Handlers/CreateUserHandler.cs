using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public CreateUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<MetWorkingUserDomain.Entities.User>(request.UserRequest);
            await _applicationDbContext.Users.AddAsync(user, cancellationToken);

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.UserRequest.Password);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }
    }
}