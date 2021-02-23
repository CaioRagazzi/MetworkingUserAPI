using System;

namespace MetWorkingUserApplication.User.Consumer
{
    public class UserAddBoostConsumer
    {
        public void ConsumeBroker(string bodyMessage)
        {
            Console.Out.WriteLine(bodyMessage);
        }
    }
}