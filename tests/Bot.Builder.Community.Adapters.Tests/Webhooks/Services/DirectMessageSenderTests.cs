using System;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class DirectMessageSenderTests
    {
        private static readonly Mock<IOptions<TwitterOptions>> TestOptions = new Mock<IOptions<TwitterOptions>>();

        public DirectMessageSenderTests()
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

            TestOptions.SetupGet(x => x.Value).Returns(options);
        }

        [Fact]
        public async Task SendWithEmptyMessageShouldFail()
        {
            var sender = new DirectMessageSender(TestOptions.Object.Value);

            await Assert.ThrowsAsync<TwitterException>(
                async () =>
            {
                await sender.Send("test", string.Empty);
            });
        }

        [Fact]
        public async Task SendWithLongMessageShouldFail()
        {
            var sender = new DirectMessageSender(TestOptions.Object.Value);

            await Assert.ThrowsAsync<TwitterException>(
                async () =>
                {
                    await sender.Send("test", new String('a', 141));
                });
        }

        [Fact]
        public async Task SendShouldReturnUnauthorized()
        {
            var sender = new DirectMessageSender(TestOptions.Object.Value);
            var result = await sender.Send("test", "text message");

            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task SendAsyncShouldReturnUnauthorized()
        {
            var sender = new DirectMessageSender(TestOptions.Object.Value);
            var message = new NewDirectMessageObject();
            var result = await sender.SendAsync(message);

            Assert.Equal(89, result.Error.Errors[0].Code);
        }
    }
}
