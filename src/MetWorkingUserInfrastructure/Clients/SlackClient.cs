using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using MetWorkingUserApplication.Common.Models;
using MetWorkingUserApplication.Interfaces.Slack;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MetWorkingUserInfrastructure.Clients
{
    public class SlackClient : ISlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();
        private readonly IConfiguration _configuration;

        public SlackClient(IConfiguration configuration)
        {
            // _configuration = configuration;
            // var slackUrl = _configuration.GetSection("SlackURL").Value;
            // _uri = new Uri(slackUrl);
            // _configuration = configuration;
        }
        
        public string PostMessage(string text, string channel = null)
        {
            var payload = new SlackPayload
            {
                Channel = channel,
                Text = text
            };        return PostMessage(payload);
        }
        
        private string PostMessage(SlackPayload payload)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);
            using var client = new WebClient();
            var data = new NameValueCollection {["payload"] = payloadJson};            
            var response = client.UploadValues(_uri, "POST", data);
            return _encoding.GetString(response);
        }
    }
}