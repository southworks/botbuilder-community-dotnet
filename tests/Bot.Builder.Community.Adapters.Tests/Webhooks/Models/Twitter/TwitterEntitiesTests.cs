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
            var entities = new TwitterEntities()
            {
                media = new List<MediaEntity>(),
                hashtags = new List<HashtagEntity>(),
                symbols = new List<SymbolEntity>(),
                urls = new List<UrlEntity>(),
                user_mentions = new List<UserMentionEntity>()
            };

            Assert.AreEqual(typeof(List<MediaEntity>), entities.media.GetType());
            Assert.AreEqual(typeof(List<HashtagEntity>), entities.hashtags.GetType());
            Assert.AreEqual(typeof(List<SymbolEntity>), entities.symbols.GetType());
            Assert.AreEqual(typeof(List<UrlEntity>), entities.urls.GetType());
            Assert.AreEqual(typeof(List<UserMentionEntity>), entities.user_mentions.GetType());
        }
    }
}
