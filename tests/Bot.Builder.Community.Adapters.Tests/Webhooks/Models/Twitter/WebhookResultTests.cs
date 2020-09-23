// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class WebhookResultTests
    {
        [Fact]
        public void WebhookResultPropertiesShouldBeSetSuccessfully()
        {
            var webhookResult = new WebhookResult
            {
                Environments = new List<EnvironmentRegistration>()
            };

            var jsonResult = JsonConvert.DeserializeObject<WebhookResult>(JsonConvert.SerializeObject(webhookResult));
            
            Assert.Equal(webhookResult.Environments.GetType(), jsonResult.Environments.GetType());
        }
    }
}
