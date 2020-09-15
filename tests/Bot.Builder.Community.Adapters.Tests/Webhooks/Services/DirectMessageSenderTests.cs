using System;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [TestClass]
    [TestCategory("Twitter")]
    public class DirectMessageSenderTests
    {
        private static readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            var options = new TwitterOptions
            {
                WebhookUri = "uri",
                AccessSecret = "access-secret",
                AccessToken = "access-token",
                ConsumerKey = "consumer-key",
                ConsumerSecret = "consumer-secret",
                Environment = "env",
                Tier = TwitterAccountApi.PremiumFree
            };

            _testOptions.SetupGet(x => x.Value).Returns(options);
        }

        [TestMethod]
        public async Task SendWithEmptyMessageShouldFail()
        {
            var sender = new DirectMessageSender(_testOptions.Object.Value);

            await Assert.ThrowsExceptionAsync<TwitterException>(
                async () =>
            {
                await sender.Send("test", string.Empty);
            }, "You can't send an empty message.");
        }

        [TestMethod]
        public async Task SendWithLongMessageShouldFail()
        {
            var sender = new DirectMessageSender(_testOptions.Object.Value);

            await Assert.ThrowsExceptionAsync<TwitterException>(
                async () =>
                {
                    await sender.Send("test", new String('a', 141));
                }, "You can't send more than 140 char using this end point, use SendAsync instead.");
        }

        [TestMethod]
        public async Task SendShouldReturnUnauthorized()
        {
            var sender = new DirectMessageSender(_testOptions.Object.Value);
            var result = await sender.Send("test", "text message");

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }

        [TestMethod]
        public async Task SendAsyncShouldReturnUnauthorized()
        {
            var sender = new DirectMessageSender(_testOptions.Object.Value);
            var message = new NewDirectMessageObject();
            var result = await sender.SendAsync(message);

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }
    }
}
