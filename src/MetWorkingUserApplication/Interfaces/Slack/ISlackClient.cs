namespace MetWorkingUserApplication.Interfaces.Slack
{
    public interface ISlackClient
    {
        string PostMessage(string text, string channel = null);
    }
}