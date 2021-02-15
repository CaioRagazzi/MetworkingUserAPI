using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.User.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse<string>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DeleteUserHandler(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public async Task<BaseResponse<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Users.FindAsync(request.Id);

            var response = new BaseResponse<string>();
            if (entity == null)
            {
                response.SetValidationErrors(new []{"User Not Found!"});
                return response;
            }

            _applicationDbContext.Users.Remove(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            response.SetIsOk($"User {entity.Name} has been updated!");

            return response;
        }
    }
}