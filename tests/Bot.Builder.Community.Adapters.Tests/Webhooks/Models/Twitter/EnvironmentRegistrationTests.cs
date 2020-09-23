// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class EnvironmentRegistrationTests
    {
        [Fact]
        public void EnvironmentRegistrationPropertiesShouldBeSetSuccessfully()
        {
            var environmentRegistration = new EnvironmentRegistration
            {
                Name = "env-name",
                Webhooks = new List<WebhookRegistration>()
            };

            var jsonResult = JsonConvert.DeserializeObject<EnvironmentRegistration>(JsonConvert.SerializeObject(environmentRegistration));

            Assert.Equal(environmentRegistration.Name, jsonResult.Name);
            Assert.Equal(environmentRegistration.Webhooks.GetType(), jsonResult.Webhooks.GetType());
        }
    }
}
