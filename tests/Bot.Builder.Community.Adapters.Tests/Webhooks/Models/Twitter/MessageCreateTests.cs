// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class MessageCreateTests
    {
        [Fact]
        public void MessageCreatePropertiesShouldBeSetSuccessfully()
        {
            var messageCreate = new MessageCreate
            {
                id = 1,
                id_str = "id-1",
                created_at = "2020-09-01T15:07:18Z",
                entities = new TwitterEntities(),
                recipient = new TwitterFullUser(),
                recipient_id = 1,
                recipient_id_str = "id-1",
                recipient_screen_name = "recipient-screen-name",
                sender = new TwitterFullUser(),
                sender_id = 2,
                sender_id_str = "id-2",
                sender_screen_name = "sender-screen-name",
                text = "test-text"
            };

            Assert.Equal(1, messageCreate.id);
            Assert.Equal("id-1", messageCreate.id_str);
            Assert.Equal("2020-09-01T15:07:18Z", messageCreate.created_at);
            Assert.Equal(typeof(TwitterEntities), messageCreate.entities.GetType());
            Assert.Equal(typeof(TwitterFullUser), messageCreate.recipient.GetType());
            Assert.Equal(1, messageCreate.recipient_id);
            Assert.Equal("id-1", messageCreate.recipient_id_str);
            Assert.Equal("recipient-screen-name", messageCreate.recipient_screen_name);
            Assert.Equal(typeof(TwitterFullUser), messageCreate.sender.GetType());
            Assert.Equal(2, messageCreate.sender_id);
            Assert.Equal("id-2", messageCreate.sender_id_str);
            Assert.Equal("sender-screen-name", messageCreate.sender_screen_name);
            Assert.Equal("test-text", messageCreate.text);
        }

        [Fact]
        public void TwitterFullUserPropertiesShouldBeSetSuccessfully()
        {
            var twitterFullUser = new TwitterFullUser
            {
                id = 1,
                id_str = "id-1",
                created_at = "2020-09-01T15:07:18Z",
                entities = new TwitterEntities(),
                url = "https://url",
                screen_name = "screen-name",
                _protected = true,
                contributors_enabled = true,
                default_profile = true,
                default_profile_image = true,
                description = "user-description",
                favourites_count = 3,
                follow_request_sent = true,
                followers_count = 13,
                following = true,
                friends_count = 23,
                geo_enabled = true,
                has_extended_profile = true,
                is_translation_enabled = true,
                is_translator = true,
                lang = "en_US",
                listed_count = 33,
                location = "location",
                name = "user-name",
                notifications = true,
                profile_background_color = "green",
                profile_background_image_url = "http://background-image-url",
                profile_background_image_url_https = "https://background-image-url",
                profile_background_tile = true,
                profile_banner_url = "https://profile-banner-url",
                profile_image_url = "http://profile-image-url",
                profile_image_url_https = "https://profile-image-url",
                profile_link_color = "red",
                profile_sidebar_border_color = "black",
                profile_sidebar_fill_color = "white",
                profile_text_color = "black",
                profile_use_background_image = true,
                statuses_count = 5,
                time_zone = "GMT",
                translator_type = "translator",
                utc_offset = "-3",
                verified = true
            };

            Assert.Equal(1, twitterFullUser.id);
            Assert.Equal("id-1", twitterFullUser.id_str);
            Assert.Equal("2020-09-01T15:07:18Z", twitterFullUser.created_at);
            Assert.Equal(typeof(TwitterEntities), twitterFullUser.entities.GetType());
            Assert.Equal("https://url", twitterFullUser.url);
            Assert.Equal("screen-name", twitterFullUser.screen_name);
            Assert.True(twitterFullUser._protected);
            Assert.True(twitterFullUser.contributors_enabled);
            Assert.True(twitterFullUser.default_profile);
            Assert.True(twitterFullUser.default_profile_image);
            Assert.Equal("user-description", twitterFullUser.description);
            Assert.Equal(3, twitterFullUser.favourites_count);
            Assert.True(twitterFullUser.follow_request_sent);
            Assert.Equal(13, twitterFullUser.followers_count);
            Assert.True(twitterFullUser.following);
            Assert.Equal(23, twitterFullUser.friends_count);
            Assert.True(twitterFullUser.geo_enabled);
            Assert.True(twitterFullUser.has_extended_profile);
            Assert.True(twitterFullUser.is_translation_enabled);
            Assert.True(twitterFullUser.is_translator);
            Assert.Equal("en_US", twitterFullUser.lang);
            Assert.Equal(33, twitterFullUser.listed_count);
            Assert.Equal("location", twitterFullUser.location);
            Assert.Equal("user-name", twitterFullUser.name);
            Assert.True(twitterFullUser.notifications);
            Assert.Equal("green", twitterFullUser.profile_background_color);
            Assert.Equal("http://background-image-url", twitterFullUser.profile_background_image_url);
            Assert.Equal("https://background-image-url", twitterFullUser.profile_background_image_url_https);
            Assert.True(twitterFullUser.profile_background_tile);
            Assert.Equal("https://profile-banner-url", twitterFullUser.profile_banner_url);
            Assert.Equal("http://profile-image-url", twitterFullUser.profile_image_url);
            Assert.Equal("https://profile-image-url", twitterFullUser.profile_image_url_https);
            Assert.Equal("red", twitterFullUser.profile_link_color);
            Assert.Equal("black", twitterFullUser.profile_sidebar_border_color);
            Assert.Equal("white", twitterFullUser.profile_sidebar_fill_color);
            Assert.Equal("black", twitterFullUser.profile_text_color);
            Assert.True(twitterFullUser.profile_use_background_image);
            Assert.Equal(5, twitterFullUser.statuses_count);
            Assert.Equal("GMT", twitterFullUser.time_zone);
            Assert.Equal("translator", twitterFullUser.translator_type);
            Assert.Equal("-3", twitterFullUser.utc_offset);
            Assert.True(twitterFullUser.verified);
        }
    }
}
