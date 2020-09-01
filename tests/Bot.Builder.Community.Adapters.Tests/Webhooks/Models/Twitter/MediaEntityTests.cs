using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class MediaEntityTests
    {
        [TestMethod]
        public void MediaEntityPropertiesShouldBeSetSuccessfully()
        {
            var media = new MediaEntity()
            {
                id = 1,
                id_str = "id-1",
                display_url = "https://display-url",
                expanded_url = "https://expanded-url",
                media_url = "http://media-url",
                media_url_https = "https://media-url",
                url = "https://url",
                type = "media-type",
                indices = new[] { 0, 1, 2 },
                sizes = new Sizes()
                {
                    thumb = new TwitterSizeThumb() { h = 128, w = 72, resize = "resize" },
                    small = new TwitterSizeSmall() { h = 640, w = 360, resize = "resize" },
                    medium = new TwitterSizeMedium() { h = 1280, w = 720, resize = "resize" },
                    large = new TwitterSizeLarge() { h = 1920, w = 1080, resize = "resize" }
                }
            };

            Assert.AreEqual(1, media.id);
            Assert.AreEqual("id-1", media.id_str);
            Assert.AreEqual("https://display-url", media.display_url);
            Assert.AreEqual("https://expanded-url", media.expanded_url);
            Assert.AreEqual("http://media-url", media.media_url);
            Assert.AreEqual("https://media-url", media.media_url_https);
            Assert.AreEqual("https://url", media.url);
            Assert.AreEqual("media-type", media.type);
            Assert.AreEqual(3, media.indices.Length);
            // TwitterSizeThumb
            Assert.AreEqual(128, media.sizes.thumb.h);
            Assert.AreEqual(72, media.sizes.thumb.w);
            Assert.AreEqual("resize", media.sizes.thumb.resize);
            // TwitterSizeSmall
            Assert.AreEqual(640, media.sizes.small.h);
            Assert.AreEqual(360, media.sizes.small.w);
            Assert.AreEqual("resize", media.sizes.small.resize);
            // TwitterSizeMedium
            Assert.AreEqual(1280, media.sizes.medium.h);
            Assert.AreEqual(720, media.sizes.medium.w);
            Assert.AreEqual("resize", media.sizes.medium.resize);
            // TwitterSizeLarge
            Assert.AreEqual(1920, media.sizes.large.h);
            Assert.AreEqual(1080, media.sizes.large.w);
            Assert.AreEqual("resize", media.sizes.large.resize);
        }
    }
}
