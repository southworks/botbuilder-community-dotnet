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
            var entity = new UrlEntity()
            {
                url = "https://url",
                display_url = "https://display-url",
                expanded_url = "https://expanded-url",
                indices = new[] { 0, 1, 2 }
            };

            Assert.AreEqual("https://url", entity.url);
            Assert.AreEqual("https://display-url", entity.display_url);
            Assert.AreEqual("https://expanded-url", entity.expanded_url);
            Assert.AreEqual(3, entity.indices.Length);
        }
    }
}
