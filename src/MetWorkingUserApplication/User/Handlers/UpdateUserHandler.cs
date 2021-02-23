using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.User.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<UserResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        public async Task<BaseResponse<UserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userRequest = _mapper.Map<MetWorkingUserDomain.Entities.User>(request.UserUpdateRequest);

            var user = await _applicationDbContext.Users.FindAsync(userRequest.Id);

            var response = new BaseResponse<UserResponse>();
            if (user == null)
            {
                response.SetValidationErrors(new []{"User Not Found!"});
                return response;
            }

            user.Email = userRequest.Email;
            user.Name = userRequest.Name;
            user.Description = userRequest.Description;
            user.Company = userRequest.Company;
            user.Role = userRequest.Role;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            var userResponse = _mapper.Map<UserResponse>(user);
            
            response.SetIsOk(userResponse);

            return response;
        }
    }
}