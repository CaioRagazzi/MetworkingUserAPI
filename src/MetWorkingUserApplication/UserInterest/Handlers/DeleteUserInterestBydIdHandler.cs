using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.UserInterest.Commands;
using Microsoft.EntityFrameworkCore;

namespace MetWorkingUserApplication.UserInterest.Handlers
{
    public class DeleteUserInterestBydIdHandler : IRequestHandler<DeleteUserInterestByIdCommand, BaseResponse<string>>
    {
        public DeleteUserInterestBydIdHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private readonly IApplicationDbContext _applicationDbContext;
        
        public async Task<BaseResponse<string>> Handle(DeleteUserInterestByIdCommand request, CancellationToken cancellationToken)
        {
            var userInterestToDelete = await _applicationDbContext.UserInterests.FirstOrDefaultAsync(userInt =>
                    userInt.UserId == request.UserId && userInt.InterestId == request.InterestId, cancellationToken: cancellationToken);

            var response = new BaseResponse<string>();
            if (userInterestToDelete == null)
            {
                response.SetValidationErrors(new []{"UserInterest not found!"});
                return response;
            }

            _applicationDbContext.UserInterests.Remove(userInterestToDelete);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            response.SetIsOk("User interest has been deleted!");
            return response;
        }
    }
}