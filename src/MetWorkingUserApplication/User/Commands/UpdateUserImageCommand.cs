using System;
using MediatR;
using MetWorkingUserApplication.Contracts.Response;

namespace MetWorkingUserApplication.User.Commands
{
    public class UpdateUserImageCommand : IRequest<BaseResponse<string>>
    {
        public UpdateUserImageCommand(string imageBase64, Guid userId)
        {
            this.ImageUrl = imageBase64;
            this.UserId = userId;
        }

        public string ImageUrl { get; set; }
        public Guid UserId { get; set; }
    }
}