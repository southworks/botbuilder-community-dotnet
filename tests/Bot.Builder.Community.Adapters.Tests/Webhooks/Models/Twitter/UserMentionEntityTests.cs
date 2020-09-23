// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class UserMentionEntityTests
    {
        [Fact]
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

            Assert.Equal(1, userMention.id);
            Assert.Equal("id-1", userMention.id_str);
            Assert.Equal("user-mention-name", userMention.name);
            Assert.Equal("user-mention-screen-name", userMention.screen_name);
            Assert.Equal(3, userMention.indices.Length);
        }
    }
}
