// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class EnvironmentRegistrationTests
    {
        [TestMethod]
        public void EnvironmentRegistrationPropertiesShouldBeSetSuccessfully()
        {
            var environmentRegistration = new EnvironmentRegistration
            {
                Name = "env-name",
                Webhooks = new List<WebhookRegistration>()
            };

            var jsonResult = JsonConvert.DeserializeObject<EnvironmentRegistration>(JsonConvert.SerializeObject(environmentRegistration));

            Assert.AreEqual(environmentRegistration.Name, jsonResult.Name);
            Assert.AreEqual(environmentRegistration.Webhooks.GetType(), jsonResult.Webhooks.GetType());
        }
    }
}
