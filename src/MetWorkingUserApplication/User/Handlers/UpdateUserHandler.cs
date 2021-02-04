using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Common.Exceptions;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userRequest = _mapper.Map<User>(request.User);

            var user = await _applicationDbContext.Users.FindAsync(userRequest.Id);

            if (user == null)
            {
                throw new NotFoundException();
            }

            user.Email = userRequest.Email;
            user.Name = userRequest.Name;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserResponse>(user);
        }
    }
}