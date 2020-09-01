// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class UserMentionEntityTests
    {
        [TestMethod]
        public void UserMentionEntityPropertiesShouldBeSetSuccessfully()
        {
            var userMention = new UserMentionEntity
            {
                id = 1,
                id_str = "id-1",
                name = "user-mention-name",
                screen_name = "user-mention-screen-name",
                indices = new[] { 0, 1, 2 }
            };

            Assert.AreEqual(1, userMention.id);
            Assert.AreEqual("id-1", userMention.id_str);
            Assert.AreEqual("user-mention-name", userMention.name);
            Assert.AreEqual("user-mention-screen-name", userMention.screen_name);
            Assert.AreEqual(3, userMention.indices.Length);
        }
    }
}
