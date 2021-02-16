using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.User.Commands
{
    public class UpdateUserImageCommand : IRequest<BaseResponse<string>>
    {
        public UpdateUserImageCommand(byte[] imageBase64, Guid userId)
        {
            this.imageBase64 = imageBase64;
            this.UserId = userId;
        }

        public byte[] imageBase64 { get; set; }
        public Guid UserId { get; set; }
    }
}