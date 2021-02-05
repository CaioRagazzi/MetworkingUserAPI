using System.Threading.Tasks;
using NUnit.Framework;

namespace MetWorkingUser.Application.Integration.Tests
{
    using static Testing;
    public class TestBase
    {
        [SetUp]
        public async Task Setup()
        {
            await ResetState();
        }
    }
}