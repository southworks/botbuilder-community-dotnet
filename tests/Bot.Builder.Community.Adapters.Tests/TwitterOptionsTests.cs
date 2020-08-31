// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [TestClass]
    [TestCategory("Twitter")]
    public class TwitterOptionsTests
    {
        [TestMethod]
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

            Assert.AreEqual("bot-username", options.BotUsername);
            Assert.AreEqual("usernames", options.AllowedUsernames[0]);
            Assert.AreEqual(TwitterAccountApi.PremiumFree, options.Tier);
            Assert.IsTrue(options.IsValid);
            Assert.AreEqual("consumer-key", options.ConsumerKey);
            Assert.AreEqual("consumer-secret", options.ConsumerSecret);
            Assert.AreEqual("access-token", options.AccessToken);
            Assert.AreEqual("access-secret", options.AccessSecret);
            Assert.AreEqual("env", options.Environment);
            Assert.AreEqual("uri", options.WebhookUri);
            Assert.IsTrue(options.AllowedUsernamesConfigured());
        }
    }
}
