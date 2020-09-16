// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models
{
    [Trait("TestCategory", "Twitter")]
    public class DirectMessageEventTests
    {
        [Fact]
        public void DirectMessageEventShouldBeSetSuccessfully()
        {
            var hashtag = new HashtagEntity
            {
                text = "test-hashtag"
            };

            var hashtagList = new List<HashtagEntity>
            {
                hashtag
            };

            var directMessage = new DirectMessageEvent
            {
                Recipient = new TwitterUser { Id = "test-recipient" },
                Sender = new TwitterUser { Id = "test-sender" },
                MessageText = "test-message",
                MessageEntities = new TwitterEntities { hashtags = hashtagList },
                JsonSource = "test-json"
            };

            Assert.Equal("test-recipient", directMessage.Recipient.Id);
            Assert.Equal("test-sender", directMessage.Sender.Id);
            Assert.Equal("test-message", directMessage.MessageText);
            Assert.Equal(hashtagList, directMessage.MessageEntities.hashtags);
            Assert.Equal("test-json", directMessage.JsonSource);
        }
    }
}
