// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var mediaEntity = new MediaEntity
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
                sizes = new Sizes
                {
                    thumb = new TwitterSizeThumb { h = 128, w = 72, resize = "resize" },
                    small = new TwitterSizeSmall { h = 640, w = 360, resize = "resize" },
                    medium = new TwitterSizeMedium { h = 1280, w = 720, resize = "resize" },
                    large = new TwitterSizeLarge { h = 1920, w = 1080, resize = "resize" }
                }
            };

            Assert.AreEqual(1, mediaEntity.id);
            Assert.AreEqual("id-1", mediaEntity.id_str);
            Assert.AreEqual("https://display-url", mediaEntity.display_url);
            Assert.AreEqual("https://expanded-url", mediaEntity.expanded_url);
            Assert.AreEqual("http://media-url", mediaEntity.media_url);
            Assert.AreEqual("https://media-url", mediaEntity.media_url_https);
            Assert.AreEqual("https://url", mediaEntity.url);
            Assert.AreEqual("media-type", mediaEntity.type);
            Assert.AreEqual(3, mediaEntity.indices.Length);
            // TwitterSizeThumb
            Assert.AreEqual(128, mediaEntity.sizes.thumb.h);
            Assert.AreEqual(72, mediaEntity.sizes.thumb.w);
            Assert.AreEqual("resize", mediaEntity.sizes.thumb.resize);
            // TwitterSizeSmall
            Assert.AreEqual(640, mediaEntity.sizes.small.h);
            Assert.AreEqual(360, mediaEntity.sizes.small.w);
            Assert.AreEqual("resize", mediaEntity.sizes.small.resize);
            // TwitterSizeMedium
            Assert.AreEqual(1280, mediaEntity.sizes.medium.h);
            Assert.AreEqual(720, mediaEntity.sizes.medium.w);
            Assert.AreEqual("resize", mediaEntity.sizes.medium.resize);
            // TwitterSizeLarge
            Assert.AreEqual(1920, mediaEntity.sizes.large.h);
            Assert.AreEqual(1080, mediaEntity.sizes.large.w);
            Assert.AreEqual("resize", mediaEntity.sizes.large.resize);
        }
    }
}
