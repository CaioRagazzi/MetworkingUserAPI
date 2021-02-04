using AutoMapper;
using MetWorkingUserApplication.Contracts.Request;
using MetWorkingUserApplication.Contracts.Response;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Mapping
{
    public class DomainToResponseUser : Profile
    {
        public DomainToResponseUser()
        {
            CreateMap<User, UserResponse>();
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Id, act => act.Ignore());
        }
    }   
}