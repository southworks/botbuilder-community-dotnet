// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class MediaEntityTests
    {
        [Fact]
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

            Assert.Equal(1, mediaEntity.id);
            Assert.Equal("id-1", mediaEntity.id_str);
            Assert.Equal("https://display-url", mediaEntity.display_url);
            Assert.Equal("https://expanded-url", mediaEntity.expanded_url);
            Assert.Equal("http://media-url", mediaEntity.media_url);
            Assert.Equal("https://media-url", mediaEntity.media_url_https);
            Assert.Equal("https://url", mediaEntity.url);
            Assert.Equal("media-type", mediaEntity.type);
            Assert.Equal(3, mediaEntity.indices.Length);
            // TwitterSizeThumb
            Assert.Equal(128, mediaEntity.sizes.thumb.h);
            Assert.Equal(72, mediaEntity.sizes.thumb.w);
            Assert.Equal("resize", mediaEntity.sizes.thumb.resize);
            // TwitterSizeSmall
            Assert.Equal(640, mediaEntity.sizes.small.h);
            Assert.Equal(360, mediaEntity.sizes.small.w);
            Assert.Equal("resize", mediaEntity.sizes.small.resize);
            // TwitterSizeMedium
            Assert.Equal(1280, mediaEntity.sizes.medium.h);
            Assert.Equal(720, mediaEntity.sizes.medium.w);
            Assert.Equal("resize", mediaEntity.sizes.medium.resize);
            // TwitterSizeLarge
            Assert.Equal(1920, mediaEntity.sizes.large.h);
            Assert.Equal(1080, mediaEntity.sizes.large.w);
            Assert.Equal("resize", mediaEntity.sizes.large.resize);
        }
    }
}
