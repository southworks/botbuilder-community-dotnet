// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class WebhookRegistrationTests
    {
        [TestMethod]
        public void WebhookRegistrationPropertiesShouldBeSetSuccessfully()
        {
            var webhookRegistration = new WebhookRegistration
            {
                Id = "webhook-id",
                RegisteredUrl = "https://registered-url",
                IsValid = true,
                CreatedTimestamp = 3000
            };

            var jsonResult = JsonConvert.DeserializeObject<WebhookRegistration>(JsonConvert.SerializeObject(webhookRegistration));

            Assert.AreEqual(webhookRegistration.Id, jsonResult.Id);
            Assert.AreEqual(webhookRegistration.RegisteredUrl, jsonResult.RegisteredUrl);
            Assert.AreEqual(webhookRegistration.IsValid, jsonResult.IsValid);
            Assert.AreEqual(webhookRegistration.CreatedTimestamp, jsonResult.CreatedTimestamp);
        }
    }
}
