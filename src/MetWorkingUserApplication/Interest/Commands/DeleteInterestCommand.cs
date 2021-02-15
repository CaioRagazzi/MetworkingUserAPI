using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.Interest.Commands
{
    public class DeleteInterestCommand : IRequest<BaseResponse<string>>
    {
        public DeleteInterestCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}