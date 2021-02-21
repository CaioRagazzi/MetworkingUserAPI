using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.UserInterest.Commands;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.UserInterest.Handlers
{
    public class CreateUserInterestHandler : IRequestHandler<CreateUserInterestCommand, BaseResponse<string>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateUserInterestHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        
        public async Task<BaseResponse<string>> Handle(CreateUserInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = await _applicationDbContext.Interest.FindAsync(request.InterestId);
            var user = await _applicationDbContext.Users.FindAsync(request.UserId);

            var response = new BaseResponse<string>();
            if (interest == null || user == null)
            {
                response.SetValidationErrors(new []{"Interest not found!"});
                return response;
            }

            var userInterests = new UserInterests()
            {
                Interest = interest,
                User = user,
                InterestId = request.InterestId,
                UserId = request.UserId
            };

            await _applicationDbContext.UserInterests.AddAsync(userInterests, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            response.SetIsOk("User Interest has been created!");
            return response;
        }
    }
}