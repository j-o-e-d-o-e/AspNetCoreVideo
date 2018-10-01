namespace AspNetCoreVideo.Services
{
    public class HardcodedMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hardcoded message form a service";
        }
    }
}