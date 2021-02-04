using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; }   

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        } 
        
    }
}