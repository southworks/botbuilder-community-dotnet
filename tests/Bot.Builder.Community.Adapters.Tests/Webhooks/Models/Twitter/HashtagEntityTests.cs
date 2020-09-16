// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class HashtagEntityTests
    {
        [Fact]
        public void HashtagEntityPropertiesShouldBeSetSuccessfully()
        {
            var hashtagEntity = new HashtagEntity
            {
                text = "hashtag-text",
                indices = new[] { 0, 1, 2 }
            };

            Assert.Equal("hashtag-text", hashtagEntity.text);
            Assert.Equal(3, hashtagEntity.indices.Length);
        }
    }
}
