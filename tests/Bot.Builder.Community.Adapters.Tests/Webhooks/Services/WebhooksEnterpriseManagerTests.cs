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
    public class WebhooksEnterpriseManagerTests
    {
        private readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        public WebhooksEnterpriseManagerTests()
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
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);
            var result = await enterpriseManager.GetRegisteredWebhooks();

            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task RegisterWebhookShouldReturnUnauthorized()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);
            var result = await enterpriseManager.RegisterWebhook("webhook-url");

            Assert.Equal(89, result.Error.Errors[0].Code);
        }

        [Fact]
        public async Task RegisterWebhookWithEmptyUrlShouldFail()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);

            await Assert.ThrowsAsync<ArgumentException>(async () => { await enterpriseManager.RegisterWebhook(string.Empty); });
        }

        [Fact]
        public async Task UnregisterWebhookShouldReturnUnauthorized()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);
            var result = await enterpriseManager.UnregisterWebhook("webhook-id");

            Assert.Equal(89, result.Error.Errors[0].Code);
        }
    }
}
