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
            var userMention = new MessageCreate()
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

            Assert.AreEqual(1, userMention.id);
            Assert.AreEqual("id-1", userMention.id_str);
            Assert.AreEqual("2020-09-01T15:07:18Z", userMention.created_at);
            Assert.AreEqual(typeof(TwitterEntities), userMention.entities.GetType());
            Assert.AreEqual(typeof(TwitterFullUser), userMention.recipient.GetType());
            Assert.AreEqual(1, userMention.recipient_id);
            Assert.AreEqual("id-1", userMention.recipient_id_str);
            Assert.AreEqual("recipient-screen-name", userMention.recipient_screen_name);
            Assert.AreEqual(typeof(TwitterFullUser), userMention.sender.GetType());
            Assert.AreEqual(2, userMention.sender_id);
            Assert.AreEqual("id-2", userMention.sender_id_str);
            Assert.AreEqual("sender-screen-name", userMention.sender_screen_name);
            Assert.AreEqual("test-text", userMention.text);
        }

        [TestMethod]
        public void TwitterFullUserPropertiesShouldBeSetSuccessfully()
        {
            var user = new TwitterFullUser()
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

            Assert.AreEqual(1, user.id);
            Assert.AreEqual("id-1", user.id_str);
            Assert.AreEqual("2020-09-01T15:07:18Z", user.created_at);
            Assert.AreEqual(typeof(TwitterEntities), user.entities.GetType());
            Assert.AreEqual("https://url", user.url);
            Assert.AreEqual("screen-name", user.screen_name);
            Assert.IsTrue(user._protected);
            Assert.IsTrue(user.contributors_enabled);
            Assert.IsTrue(user.default_profile);
            Assert.IsTrue(user.default_profile_image);
            Assert.AreEqual("user-description", user.description);
            Assert.AreEqual(3, user.favourites_count);
            Assert.IsTrue(user.follow_request_sent);
            Assert.AreEqual(13, user.followers_count);
            Assert.IsTrue(user.following);
            Assert.AreEqual(23, user.friends_count);
            Assert.IsTrue(user.geo_enabled);
            Assert.IsTrue(user.has_extended_profile);
            Assert.IsTrue(user.is_translation_enabled);
            Assert.IsTrue(user.is_translator);
            Assert.AreEqual("en_US", user.lang);
            Assert.AreEqual(33, user.listed_count);
            Assert.AreEqual("location", user.location);
            Assert.AreEqual("user-name", user.name);
            Assert.IsTrue(user.notifications);
            Assert.AreEqual("green", user.profile_background_color);
            Assert.AreEqual("http://background-image-url", user.profile_background_image_url);
            Assert.AreEqual("https://background-image-url", user.profile_background_image_url_https);
            Assert.IsTrue(user.profile_background_tile);
            Assert.AreEqual("https://profile-banner-url", user.profile_banner_url);
            Assert.AreEqual("http://profile-image-url", user.profile_image_url);
            Assert.AreEqual("https://profile-image-url", user.profile_image_url_https);
            Assert.AreEqual("red", user.profile_link_color);
            Assert.AreEqual("black", user.profile_sidebar_border_color);
            Assert.AreEqual("white", user.profile_sidebar_fill_color);
            Assert.AreEqual("black", user.profile_text_color);
            Assert.IsTrue(user.profile_use_background_image);
            Assert.AreEqual(5, user.statuses_count);
            Assert.AreEqual("GMT", user.time_zone);
            Assert.AreEqual("translator", user.translator_type);
            Assert.AreEqual("-3", user.utc_offset);
            Assert.IsTrue(user.verified);
        }
    }
}
