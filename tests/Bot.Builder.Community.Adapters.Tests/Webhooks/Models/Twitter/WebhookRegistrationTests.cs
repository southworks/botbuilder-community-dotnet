// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class WebhookRegistrationTests
    {
        [Fact]
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

            Assert.Equal(webhookRegistration.Id, jsonResult.Id);
            Assert.Equal(webhookRegistration.RegisteredUrl, jsonResult.RegisteredUrl);
            Assert.Equal(webhookRegistration.IsValid, jsonResult.IsValid);
            Assert.Equal(webhookRegistration.CreatedTimestamp, jsonResult.CreatedTimestamp);
        }
    }
}
