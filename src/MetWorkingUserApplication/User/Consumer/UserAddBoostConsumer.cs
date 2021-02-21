// namespace MetWorkingUserApplication.User.Consumer
// {
//     using System;
//     using System.Threading.Tasks;
//     using Interfaces;
//     using MassTransit;
//     using MetWorkingUserDomain.Entities;
//
//     public class UserAddBoostConsumer : IConsumer<User>
//     {
//         private readonly IApplicationDbContext _applicationDbContext;
//
//         public UserAddBoostConsumer(IApplicationDbContext applicationDbContext)
//         {
//             _applicationDbContext = applicationDbContext;
//         }
//
//         public async Task Consume(ConsumeContext<User> context)
//         {
//             var user = await _applicationDbContext.Users.FindAsync(context.Message.Id);
//             await Console.Out.WriteLineAsync(context.Message.Name);
//         }
//     }
// }