// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var twitterUser = new TwitterUser
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

            var jsonResult = JsonConvert.DeserializeObject<TwitterUser>(JsonConvert.SerializeObject(twitterUser));

            Assert.AreEqual(twitterUser.Id, jsonResult.Id);
            Assert.AreEqual(twitterUser.Name, jsonResult.Name);
            Assert.AreEqual(twitterUser.CreatedTimestamp, jsonResult.CreatedTimestamp);
            Assert.AreEqual(twitterUser.Description, jsonResult.Description);
            Assert.AreEqual(twitterUser.FollowersCount, jsonResult.FollowersCount);
            Assert.AreEqual(twitterUser.FriendsCount, jsonResult.FriendsCount);
            Assert.AreEqual(twitterUser.IsProtected, jsonResult.IsProtected);
            Assert.AreEqual(twitterUser.IsVerified, jsonResult.IsVerified);
            Assert.AreEqual(twitterUser.Location, jsonResult.Location);
            Assert.AreEqual(twitterUser.ProfileImage, jsonResult.ProfileImage);
            Assert.AreEqual(twitterUser.ProfileImageHttps, jsonResult.ProfileImageHttps);
            Assert.AreEqual(twitterUser.ScreenName, jsonResult.ScreenName);
            Assert.AreEqual(twitterUser.StatusesCount, jsonResult.StatusesCount);
            Assert.AreEqual(twitterUser.Url, jsonResult.Url);
        }
    }
}
