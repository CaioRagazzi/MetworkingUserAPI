using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserApplication.Interfaces;
using MetWorkingUserApplication.User.Queries;
using MetWorkingUserDomain.Interfaces;

namespace MetWorkingUserApplication.User.Handlers
{
    public class GetTimelineHandler : IRequestHandler<GetTimelineQuery, BaseResponse<List<UserResponse>>>
    {
        private IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly IGeoService _geoService;

        public GetTimelineHandler(IApplicationDbContext context, IMapper mapper, IGeoService geoService)
        {
            _applicationDbContext = context;
            _mapper = mapper;
            _geoService = geoService;
        }
        
        public async Task<BaseResponse<List<UserResponse>>> Handle(GetTimelineQuery request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FindAsync(request.Id);
            
            var response = new BaseResponse<List<UserResponse>>();
            
            if (user == null)
            {
                response.SetValidationErrors(new []{"User Not Found!"});
                return response;
            }

            var userTimeline = await _geoService.GetUserTimeLine(request.Id);

            var userList = new List<UserResponse>();

            if (userTimeline != null)
                foreach (var userGuid in userTimeline)
                {
                    var findUserAsync = await _applicationDbContext.Users.FindAsync(userGuid.idAmigo);
                    if (findUserAsync != null)
                    {
                        var userResponse = _mapper.Map<UserResponse>(findUserAsync);
                        userList.Add(userResponse);
                    }
                }

            if (userTimeline != null && userTimeline.Count == 0)
            {
                response.SetValidationErrors(new []{"Timeline vazia!"});
                return response;
            }
            
            response.SetIsOk(userList);

            return response;
        }
    }
}