using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MetWorkingUserApplication.Commands;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Commands;

namespace MetWorkingUserApplication.User.Handlers
{
    public class UpdateUserImageHandler: IRequestHandler<UpdateUserImageCommand, BaseResponse<string>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateUserImageHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponse<string>> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FindAsync(request.UserId);
            
            var response = new BaseResponse<string>();
            if (user == null)
            {
                response.SetValidationErrors(new []{"User Not Found!"});
                return response;
            }

            user.Image = request.ImageUrl;
            
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            response.SetIsOk("Image Updated!");
            
            return response;
        }
    }
}