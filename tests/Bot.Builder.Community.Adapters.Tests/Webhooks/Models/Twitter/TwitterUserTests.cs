using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class TwitterUserTests
    {
        [TestMethod]
        public void TwitterUserPropertiesShouldBeSetSuccessfully()
        {
            var user = new TwitterUser()
            {
                Id = "user-id",
                Name = "user-name",
                CreatedTimestamp = 3000,
                Description = "user-description",
                FollowersCount = 3,
                FriendsCount = 5,
                IsProtected = true,
                IsVerified = true,
                Location = "location",
                ProfileImage = "http://profile-image",
                ProfileImageHttps = "https://profile-image",
                ScreenName = "screen-name",
                StatusesCount = 7,
                Url = "https://url"
            };

            var jsonResult = JsonConvert.DeserializeObject<TwitterUser>(JsonConvert.SerializeObject(user));

            Assert.AreEqual(user.Id, jsonResult.Id);
            Assert.AreEqual(user.Name, jsonResult.Name);
            Assert.AreEqual(user.CreatedTimestamp, jsonResult.CreatedTimestamp);
            Assert.AreEqual(user.Description, jsonResult.Description);
            Assert.AreEqual(user.FollowersCount, jsonResult.FollowersCount);
            Assert.AreEqual(user.FriendsCount, jsonResult.FriendsCount);
            Assert.AreEqual(user.IsProtected, jsonResult.IsProtected);
            Assert.AreEqual(user.IsVerified, jsonResult.IsVerified);
            Assert.AreEqual(user.Location, jsonResult.Location);
            Assert.AreEqual(user.ProfileImage, jsonResult.ProfileImage);
            Assert.AreEqual(user.ProfileImageHttps, jsonResult.ProfileImageHttps);
            Assert.AreEqual(user.ScreenName, jsonResult.ScreenName);
            Assert.AreEqual(user.StatusesCount, jsonResult.StatusesCount);
            Assert.AreEqual(user.Url, jsonResult.Url);
        }
    }
}
