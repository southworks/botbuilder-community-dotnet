// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class UrlEntityTests
    {
        [Fact]
        public void UrlEntityPropertiesShouldBeSetSuccessfully()
        {
            var urlEntity = new UrlEntity
            {
                url = "https://url",
                display_url = "https://display-url",
                expanded_url = "https://expanded-url",
                indices = new[] { 0, 1, 2 }
            };

            Assert.Equal("https://url", urlEntity.url);
            Assert.Equal("https://display-url", urlEntity.display_url);
            Assert.Equal("https://expanded-url", urlEntity.expanded_url);
            Assert.Equal(3, urlEntity.indices.Length);
        }
    }
}
