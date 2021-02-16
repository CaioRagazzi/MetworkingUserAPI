using Newtonsoft.Json;

namespace MetWorkingUserApplication.Common.Models
{
    public class SlackPayload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }    
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}