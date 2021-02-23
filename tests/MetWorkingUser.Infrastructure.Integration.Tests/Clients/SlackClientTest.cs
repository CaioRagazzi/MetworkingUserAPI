using System.IO;
using MetWorkingUserInfrastructure.Clients;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace MetWorkingUser.Infrastructure.Integration.Tests.Clients
{
    public class SlackClientTest
    {
        private IConfiguration Configuration { get; set; }
        
        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.test.json")
                .Build();
        }
        
        [Test]
        public void ShouldSendToSlack()
        {
            var client = new SlackClient(Configuration);
            
            var result = client.PostMessage(
                "Testando integração com slack!");
        
            Assert.AreEqual("ok", result);
        }
    }
}