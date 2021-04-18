using System.Collections.Generic;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.User.Queries
{
    public class GetAllUsersQuery : IRequest<BaseResponse<List<UserResponse>>>
    {
        public readonly int Page;
        public readonly int TotalPerPage;

        public GetAllUsersQuery(int page, int totalPerPage)
        {
            Page = page;
            TotalPerPage = totalPerPage;
        }
    }
}