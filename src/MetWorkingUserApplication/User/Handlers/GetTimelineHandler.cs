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

namespace MetWorkingUserApplication.User.Handlers
{
    public class GetTimelineHandler : IRequestHandler<GetTimelineQuery, BaseResponse<List<UserResponse>>>
    {
        private IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public GetTimelineHandler(IApplicationDbContext context, IMapper mapper, HttpClient httpClient)
        {
            _applicationDbContext = context;
            _mapper = mapper;
            _httpClient = httpClient;
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

            var httpResponse = await _httpClient.GetAsync($"http://metworkinggeo:5001/timeline/{request.Id}", cancellationToken);

            if (!httpResponse.IsSuccessStatusCode)
            {
                response.SetValidationErrors(new []{"Erro ao buscar usuario!"});
                return response;
            }

            var readAsStringAsync = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
            var responseTimeLine = JsonSerializer.Deserialize<List<GeoTimelineResponse>>(readAsStringAsync);

            var userList = new List<UserResponse>();

            if (responseTimeLine != null)
                foreach (var userGuid in responseTimeLine)
                {
                    var findUserAsync = await _applicationDbContext.Users.FindAsync(userGuid.idAmigo);
                    if (findUserAsync != null)
                    {
                        var userResponse = _mapper.Map<UserResponse>(findUserAsync);
                        userList.Add(userResponse);
                    }
                }

            if (responseTimeLine == null)
            {
                response.SetValidationErrors(new []{"Timeline vazia!"});
                return response;
            }
            
            response.SetIsOk(userList);

            return response;
        }
    }
}