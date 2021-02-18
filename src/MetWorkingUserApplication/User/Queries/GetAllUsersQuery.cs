using System.Collections.Generic;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.User.Queries
{
    public class GetAllUsersQuery : IRequest<BaseResponse<List<UserResponse>>>
    {
        
    }
}