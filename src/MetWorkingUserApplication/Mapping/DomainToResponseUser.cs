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
            CreateMap<MetWorkingUserDomain.Entities.User, UserResponse>();
            CreateMap<CreateUserRequest, MetWorkingUserDomain.Entities.User>()
                .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<UpdateUserRequest, MetWorkingUserDomain.Entities.User>()
                .ForMember(dest => dest.Password, act => act.Ignore());

            CreateMap<MetWorkingUserDomain.Entities.Interest, InterestResponse>();
            CreateMap<CreateInterestRequest, MetWorkingUserDomain.Entities.Interest>();
            CreateMap<UpdateInterestRequest, MetWorkingUserDomain.Entities.Interest>();
            CreateMap<MetWorkingUserDomain.Entities.User, UserInterestResponse>();
        }
    }   
}