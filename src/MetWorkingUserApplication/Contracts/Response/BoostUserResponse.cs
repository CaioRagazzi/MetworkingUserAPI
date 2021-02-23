namespace MetWorkingUserApplication.Contracts.Response
{
    public class BoostUserResponse
    {
        public BoostUserResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}