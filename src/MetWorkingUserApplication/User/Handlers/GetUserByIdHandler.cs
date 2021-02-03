using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.Queries;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetUserByIdHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FindAsync(request.Id);

            return user;
        }
    }
}