using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Queries;

namespace MetWorkingUserApplication.User.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, BaseResponse<List<UserResponse>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public Task<BaseResponse<List<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = _applicationDbContext.Users.ToList();
            
            var userResponse = _mapper.Map<List<UserResponse>>(allUsers);
            var response = new BaseResponse<List<UserResponse>>();
            response.SetIsOk(userResponse);

            return Task.FromResult(response);
        }
    }
}