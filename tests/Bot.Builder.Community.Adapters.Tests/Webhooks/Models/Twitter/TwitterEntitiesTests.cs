// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class TwitterEntitiesTests
    {
        [TestMethod]
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

            Assert.AreEqual(typeof(List<MediaEntity>), twitterEntities.media.GetType());
            Assert.AreEqual(typeof(List<HashtagEntity>), twitterEntities.hashtags.GetType());
            Assert.AreEqual(typeof(List<SymbolEntity>), twitterEntities.symbols.GetType());
            Assert.AreEqual(typeof(List<UrlEntity>), twitterEntities.urls.GetType());
            Assert.AreEqual(typeof(List<UserMentionEntity>), twitterEntities.user_mentions.GetType());
        }
    }
}
