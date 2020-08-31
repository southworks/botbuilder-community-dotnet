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
    public class WebhooksPremiumManagerTests
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
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);

            var result = await premiumManager.GetRegisteredWebhooks();

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }

        [TestMethod]
        public async Task RegisterWebhookShouldReturnUnauthorized()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);

            var result = await premiumManager.RegisterWebhook("webhook-url", "env");
            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }

        [TestMethod]
        public async Task RegisterWebhookWithEmptyUrlShouldFail()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);

            await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            {
                await premiumManager.RegisterWebhook(string.Empty, "env_test");
            });
        }

        [TestMethod]
        public async Task UnregisterWebhookShouldReturnUnauthorized()
        {
            var premiumManager = new WebhooksPremiumManager(_testOptions.Object.Value);

            var result = await premiumManager.UnregisterWebhook("webhook-id", "env");

            Assert.AreEqual(89, result.Error.Errors[0].Code);
        }
    }
}
