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
            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.Password, act => act.Ignore());

            CreateMap<MetWorkingUserDomain.Entities.Interest, InterestResponse>();
            CreateMap<CreateInterestRequest, MetWorkingUserDomain.Entities.Interest>();
            CreateMap<UpdateInterestRequest, MetWorkingUserDomain.Entities.Interest>();
            CreateMap<User, UserInterestResponse>();
        }
    }   
}