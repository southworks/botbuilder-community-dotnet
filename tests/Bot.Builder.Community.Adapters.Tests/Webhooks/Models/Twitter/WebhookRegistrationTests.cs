using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using System.Linq;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class WebhookRegistrationTests
    {
        [TestMethod]
        public void WebhookRegistrationPropertiesShouldBeSetSuccessfully()
        {
            var webhook = new WebhookRegistration()
            {
                Id = "webhook-id",
                RegisteredUrl = "https://registered-url",
                IsValid = true,
                CreatedTimestamp = 3000
            };

            var jsonResult = JsonConvert.DeserializeObject<WebhookRegistration>(JsonConvert.SerializeObject(webhook));

            Assert.AreEqual(webhook.Id, jsonResult.Id);
            Assert.AreEqual(webhook.RegisteredUrl, jsonResult.RegisteredUrl);
            Assert.AreEqual(webhook.IsValid, jsonResult.IsValid);
            Assert.AreEqual(webhook.CreatedTimestamp, jsonResult.CreatedTimestamp);
        }
    }
}
