using System.Threading.Tasks;
using MetWorkingUserApplication.Interfaces.Slack;

namespace MetWorkingUserApplication.Services
{
    public class SlackService : ISlackService
    {
        private readonly ISlackClient _slackClient;    
        
        public SlackService(ISlackClient slackClient)
        {
            _slackClient = slackClient;
        }    
        
        public async Task<string> PostToSlack(string message)
        {
            var response = _slackClient.PostMessage(message);        
            return response;
        }
    }
}