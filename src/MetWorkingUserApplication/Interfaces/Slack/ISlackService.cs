using System.Threading.Tasks;

namespace MetWorkingUserApplication.Interfaces.Slack
{
    public interface ISlackService
    {
        Task<string> PostToSlack(string message);
    }
}