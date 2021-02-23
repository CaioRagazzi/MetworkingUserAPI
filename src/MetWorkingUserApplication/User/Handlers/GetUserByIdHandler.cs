using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.Queries;

namespace MetWorkingUserApplication.User.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, BaseResponse<UserResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetUserByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicationDbContext.Users.FindAsync(request.Id);
            
            var userResponse = _mapper.Map<UserResponse>(users);
            var response = new BaseResponse<UserResponse>();
            response.SetIsOk(userResponse);

            return response;
        }
    }
}