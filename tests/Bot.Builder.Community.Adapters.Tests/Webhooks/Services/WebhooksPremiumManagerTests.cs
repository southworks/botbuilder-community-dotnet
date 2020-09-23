// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Services
{
    [Trait("TestCategory", "Twitter")]
    public class WebhooksPremiumManagerTests
    {
        private readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        public WebhooksPremiumManagerTests()
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

        [Fact]
        public async Task GetRegisteredWebhooksShouldReturnUnauthorized()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);
            var result = await premiumManager.GetRegisteredWebhooks();

            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task RegisterWebhookShouldReturnUnauthorized()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);
            var result = await premiumManager.RegisterWebhook("webhook-url", "env");
            
            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task RegisterWebhookWithEmptyUrlShouldFail()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);

            await Assert.ThrowsAsync<ArgumentException>(() => premiumManager.RegisterWebhook(string.Empty, "env_test"));
        }

        [Fact]
        public async Task UnregisterWebhookShouldReturnUnauthorized()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);
            var result = await premiumManager.UnregisterWebhook("webhook-id", "env");

            Assert.Equal(89, result.Error.Errors[0].Code);
        }
    }
}
