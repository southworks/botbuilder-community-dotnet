using System;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Services
{
    [Trait("TestCategory", "Twitter")]
    public class SubscriptionsManagerTests
    {
        private static readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();
        private static readonly TwitterOptions _options = new TwitterOptions
        {
            WebhookUri = "uri",
            AccessSecret = "access-secret",
            AccessToken = "access-token",
            ConsumerKey = "consumer-key",
            ConsumerSecret = "consumer-secret",
            Environment = "env",
            Tier = TwitterAccountApi.PremiumFree
        };

        [Fact]
        public async Task SubscribeWithEmptyEnvironmentNameShouldFail()
        {
            var subscriptionManager = new SubscriptionsManager(_testOptions.Object.Value);

            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionManager.Subscribe(string.Empty));
        }

        [Fact]
        public async Task CheckSubscriptionWithEmptyEnvironmentNameShouldFail()
        {
            var subscriptionManager = new SubscriptionsManager(_testOptions.Object.Value);

            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionManager.CheckSubscription(string.Empty));
        }

        [Fact]
        public async Task UnsubscribeWithEmptyEnvironmentNameShouldFail()
        {
            var subscriptionManager = new SubscriptionsManager(_testOptions.Object.Value);

            await Assert.ThrowsAsync<ArgumentException>(() => subscriptionManager.Unsubscribe(string.Empty));
        }

        [Fact]
        public async Task CheckSubscriptionShouldReturnUnauthorized()
        {
            _testOptions.SetupGet(x => x.Value).Returns(_options);
            var subscriptionManager = new SubscriptionsManager(_testOptions.Object.Value);
            var result = await subscriptionManager.CheckSubscription(_testOptions.Object.Value.Environment);

            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task SubscribeShouldReturnUnauthorized()
        {
            _testOptions.SetupGet(x => x.Value).Returns(_options);
            var subscriptionManager = new SubscriptionsManager(_testOptions.Object.Value);
            var result = await subscriptionManager.Subscribe(_testOptions.Object.Value.Environment);

            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task UnsubscribeShouldReturnNotFound()
        {
            _testOptions.SetupGet(x => x.Value).Returns(_options);
            var subscriptionManager = new SubscriptionsManager(_testOptions.Object.Value);
            var result = await subscriptionManager.Unsubscribe("webhook-id");

            Assert.Null(result.Error);
        }
    }
}
