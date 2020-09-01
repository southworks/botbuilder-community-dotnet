// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class MessageCreateTests
    {
        [TestMethod]
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

            Assert.AreEqual(1, messageCreate.id);
            Assert.AreEqual("id-1", messageCreate.id_str);
            Assert.AreEqual("2020-09-01T15:07:18Z", messageCreate.created_at);
            Assert.AreEqual(typeof(TwitterEntities), messageCreate.entities.GetType());
            Assert.AreEqual(typeof(TwitterFullUser), messageCreate.recipient.GetType());
            Assert.AreEqual(1, messageCreate.recipient_id);
            Assert.AreEqual("id-1", messageCreate.recipient_id_str);
            Assert.AreEqual("recipient-screen-name", messageCreate.recipient_screen_name);
            Assert.AreEqual(typeof(TwitterFullUser), messageCreate.sender.GetType());
            Assert.AreEqual(2, messageCreate.sender_id);
            Assert.AreEqual("id-2", messageCreate.sender_id_str);
            Assert.AreEqual("sender-screen-name", messageCreate.sender_screen_name);
            Assert.AreEqual("test-text", messageCreate.text);
        }

        [TestMethod]
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

            Assert.AreEqual(1, twitterFullUser.id);
            Assert.AreEqual("id-1", twitterFullUser.id_str);
            Assert.AreEqual("2020-09-01T15:07:18Z", twitterFullUser.created_at);
            Assert.AreEqual(typeof(TwitterEntities), twitterFullUser.entities.GetType());
            Assert.AreEqual("https://url", twitterFullUser.url);
            Assert.AreEqual("screen-name", twitterFullUser.screen_name);
            Assert.IsTrue(twitterFullUser._protected);
            Assert.IsTrue(twitterFullUser.contributors_enabled);
            Assert.IsTrue(twitterFullUser.default_profile);
            Assert.IsTrue(twitterFullUser.default_profile_image);
            Assert.AreEqual("user-description", twitterFullUser.description);
            Assert.AreEqual(3, twitterFullUser.favourites_count);
            Assert.IsTrue(twitterFullUser.follow_request_sent);
            Assert.AreEqual(13, twitterFullUser.followers_count);
            Assert.IsTrue(twitterFullUser.following);
            Assert.AreEqual(23, twitterFullUser.friends_count);
            Assert.IsTrue(twitterFullUser.geo_enabled);
            Assert.IsTrue(twitterFullUser.has_extended_profile);
            Assert.IsTrue(twitterFullUser.is_translation_enabled);
            Assert.IsTrue(twitterFullUser.is_translator);
            Assert.AreEqual("en_US", twitterFullUser.lang);
            Assert.AreEqual(33, twitterFullUser.listed_count);
            Assert.AreEqual("location", twitterFullUser.location);
            Assert.AreEqual("user-name", twitterFullUser.name);
            Assert.IsTrue(twitterFullUser.notifications);
            Assert.AreEqual("green", twitterFullUser.profile_background_color);
            Assert.AreEqual("http://background-image-url", twitterFullUser.profile_background_image_url);
            Assert.AreEqual("https://background-image-url", twitterFullUser.profile_background_image_url_https);
            Assert.IsTrue(twitterFullUser.profile_background_tile);
            Assert.AreEqual("https://profile-banner-url", twitterFullUser.profile_banner_url);
            Assert.AreEqual("http://profile-image-url", twitterFullUser.profile_image_url);
            Assert.AreEqual("https://profile-image-url", twitterFullUser.profile_image_url_https);
            Assert.AreEqual("red", twitterFullUser.profile_link_color);
            Assert.AreEqual("black", twitterFullUser.profile_sidebar_border_color);
            Assert.AreEqual("white", twitterFullUser.profile_sidebar_fill_color);
            Assert.AreEqual("black", twitterFullUser.profile_text_color);
            Assert.IsTrue(twitterFullUser.profile_use_background_image);
            Assert.AreEqual(5, twitterFullUser.statuses_count);
            Assert.AreEqual("GMT", twitterFullUser.time_zone);
            Assert.AreEqual("translator", twitterFullUser.translator_type);
            Assert.AreEqual("-3", twitterFullUser.utc_offset);
            Assert.IsTrue(twitterFullUser.verified);
        }
    }
}
