using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class HashtagEntityTests
    {
        [TestMethod]
        public void HashtagEntityPropertiesShouldBeSetSuccessfully()
        {
            var hashtag = new HashtagEntity()
            {
                text = "hashtag-text",
                indices = new[] { 0, 1, 2 }
            };

            Assert.AreEqual("hashtag-text", hashtag.text);
            Assert.AreEqual(3, hashtag.indices.Length);
        }
    }
}
