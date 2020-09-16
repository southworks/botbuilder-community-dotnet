// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class TwitterOptionsTests
    {
        [Fact]
        public void TwitterOptionsPropertiesShouldBeSetSuccessfully()
        {
            var options = new TwitterOptions
            {
                BotUsername = "bot-username",
                AllowedUsernames = new string[] { "usernames" },
                Tier = TwitterAccountApi.PremiumFree,
                ConsumerKey = "consumer-key",
                ConsumerSecret = "consumer-secret",
                AccessToken = "access-token",
                AccessSecret = "access-secret",
                Environment = "env",
                WebhookUri = "uri",
            };

            Assert.Equal("bot-username", options.BotUsername);
            Assert.Equal("usernames", options.AllowedUsernames[0]);
            Assert.Equal(TwitterAccountApi.PremiumFree, options.Tier);
            Assert.True(options.IsValid);
            Assert.Equal("consumer-key", options.ConsumerKey);
            Assert.Equal("consumer-secret", options.ConsumerSecret);
            Assert.Equal("access-token", options.AccessToken);
            Assert.Equal("access-secret", options.AccessSecret);
            Assert.Equal("env", options.Environment);
            Assert.Equal("uri", options.WebhookUri);
            Assert.True(options.AllowedUsernamesConfigured());
        }
    }
}
