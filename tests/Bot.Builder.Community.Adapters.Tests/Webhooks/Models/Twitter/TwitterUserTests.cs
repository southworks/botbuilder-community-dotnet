// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class TwitterUserTests
    {
        [Fact]
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

            Assert.Equal(twitterUser.Id, jsonResult.Id);
            Assert.Equal(twitterUser.Name, jsonResult.Name);
            Assert.Equal(twitterUser.CreatedTimestamp, jsonResult.CreatedTimestamp);
            Assert.Equal(twitterUser.Description, jsonResult.Description);
            Assert.Equal(twitterUser.FollowersCount, jsonResult.FollowersCount);
            Assert.Equal(twitterUser.FriendsCount, jsonResult.FriendsCount);
            Assert.Equal(twitterUser.IsProtected, jsonResult.IsProtected);
            Assert.Equal(twitterUser.IsVerified, jsonResult.IsVerified);
            Assert.Equal(twitterUser.Location, jsonResult.Location);
            Assert.Equal(twitterUser.ProfileImage, jsonResult.ProfileImage);
            Assert.Equal(twitterUser.ProfileImageHttps, jsonResult.ProfileImageHttps);
            Assert.Equal(twitterUser.ScreenName, jsonResult.ScreenName);
            Assert.Equal(twitterUser.StatusesCount, jsonResult.StatusesCount);
            Assert.Equal(twitterUser.Url, jsonResult.Url);
        }
    }
}
