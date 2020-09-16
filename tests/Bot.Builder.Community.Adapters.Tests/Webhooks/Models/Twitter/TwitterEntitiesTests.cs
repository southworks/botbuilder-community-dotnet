// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class TwitterEntitiesTests
    {
        [Fact]
        public void TwitterEntitiesPropertiesShouldBeSetSuccessfully()
        {
            var twitterEntities = new TwitterEntities
            {
                media = new List<MediaEntity>(),
                hashtags = new List<HashtagEntity>(),
                symbols = new List<SymbolEntity>(),
                urls = new List<UrlEntity>(),
                user_mentions = new List<UserMentionEntity>()
            };

            Assert.Equal(typeof(List<MediaEntity>), twitterEntities.media.GetType());
            Assert.Equal(typeof(List<HashtagEntity>), twitterEntities.hashtags.GetType());
            Assert.Equal(typeof(List<SymbolEntity>), twitterEntities.symbols.GetType());
            Assert.Equal(typeof(List<UrlEntity>), twitterEntities.urls.GetType());
            Assert.Equal(typeof(List<UserMentionEntity>), twitterEntities.user_mentions.GetType());
        }
    }
}
