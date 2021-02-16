using System.Threading.Tasks;
using MetWorkingUserApplication.Interfaces.Slack;
using MetWorkingUserApplication.Services;
using Moq;
using NUnit.Framework;

namespace MetWorkingUser.Application.Unit.Tests.Slack
{
    public class SlackTests
    {
        private Mock<ISlackClient> _mockSlackClient;
        private SlackService _slackService;
        
        [SetUp]
        public void Setup()
        {
            _mockSlackClient = new Mock<ISlackClient>();
            _slackService = new SlackService(_mockSlackClient.Object);
        }

        [Test]
        public async Task CallSlackClient()
        {
            _mockSlackClient.Setup(x => x.PostMessage(It.IsAny<string>(), null)).Returns("ok");    
            await _slackService.PostToSlack("Test Message");
        
            _mockSlackClient.Verify(x => x.PostMessage(It.IsAny<string>(), null), Times.Once);
        }
    }
}