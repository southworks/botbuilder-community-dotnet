using System;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Services
{
    [TestClass]
    [TestCategory("Twitter")]
    public class WebhooksEnterpriseManagerTests
    {
        private readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        [TestInitialize]
        public void SetUp()
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
        public async Task GetRegisteredWebhooksShouldReturnUnauthorized()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);

            var result = await enterpriseManager.GetRegisteredWebhooks();

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }

        [TestMethod]
        public async Task RegisterWebhookShouldReturnUnauthorized()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);

            var result = await enterpriseManager.RegisterWebhook("webhook-url");

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }

        [TestMethod]
        public async Task RegisterWebhookWithEmptyUrlShouldFail()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);

            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => { await enterpriseManager.RegisterWebhook(string.Empty); });
        }

        [TestMethod]
        public async Task UnregisterWebhookShouldReturnUnauthorized()
        {
            var enterpriseManager = new WebhooksEnterpriseManager(_testOptions.Object.Value);

            var result = await enterpriseManager.UnregisterWebhook("webhook-id");

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }
    }
}
