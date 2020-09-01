// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class UrlEntityTests
    {
        [TestMethod]
        public void UrlEntityPropertiesShouldBeSetSuccessfully()
        {
            var urlEntity = new UrlEntity
            {
                url = "https://url",
                display_url = "https://display-url",
                expanded_url = "https://expanded-url",
                indices = new[] { 0, 1, 2 }
            };

            Assert.AreEqual("https://url", urlEntity.url);
            Assert.AreEqual("https://display-url", urlEntity.display_url);
            Assert.AreEqual("https://expanded-url", urlEntity.expanded_url);
            Assert.AreEqual(3, urlEntity.indices.Length);
        }
    }
}
