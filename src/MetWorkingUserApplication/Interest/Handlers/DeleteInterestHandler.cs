using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interest.Commands;
using MetWorkingUserApplication.Interfaces;

namespace MetWorkingUserApplication.Interest.Handlers
{
    public class DeleteInterestHandler : IRequestHandler<DeleteInterestCommand, BaseResponse<string>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public DeleteInterestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }
        
        public async Task<BaseResponse<string>> Handle(DeleteInterestCommand request, CancellationToken cancellationToken)
        {
            var interest = await _applicationDbContext.Interest.FindAsync(request.Id);

            var response = new BaseResponse<string>();
            if (interest == null)
            {
                response.SetValidationErrors(new []{"Interest Not Found!"});
                return response;
            }

            _applicationDbContext.Interest.Remove(interest);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            response.SetIsOk("Interest has been removed!");
            
            return response;
        }
    }
}