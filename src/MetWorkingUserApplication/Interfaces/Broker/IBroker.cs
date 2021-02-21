namespace MetWorkingUserApplication.Interfaces.Broker
{
    public interface IBroker
    {
        public void Connect(string connectionString);
        public byte[] CreateMessage<T>(T message);
        public void Publish(byte[] message, string queue);
        public string Consumer(string queue);
    }
}