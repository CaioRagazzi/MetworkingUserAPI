using System;
using MediatR;
using MetWorkingUserDomain.Entities;

namespace MetWorkingUserApplication.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; }   

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        } 
        
    }
}