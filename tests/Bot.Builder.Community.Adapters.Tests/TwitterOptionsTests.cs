using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Castle.Core.Internal;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Options;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [TestClass]
    [TestCategory("Twitter")]
    public class TwitterOptionsTests
    {
        [TestMethod]
        public async Task TwitterOptionsProperties()
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
            Assert.AreEqual(true, options.IsValid);
            Assert.AreEqual("consumer-key", options.ConsumerKey);
            Assert.AreEqual("consumer-secret", options.ConsumerSecret);
            Assert.AreEqual("access-token", options.AccessToken);
            Assert.AreEqual("access-secret", options.AccessSecret);
            Assert.AreEqual("env", options.Environment);
            Assert.AreEqual("uri", options.WebhookUri);
            Assert.AreEqual(true, options.AllowedUsernamesConfigured());
        }
    }
}
