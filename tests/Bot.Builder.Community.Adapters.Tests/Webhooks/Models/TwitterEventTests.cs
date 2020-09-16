// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models
{
    [Trait("TestCategory", "Twitter")]
    public class TwitterEventTests
    {
        [Fact]
        public void TwitterEventShouldBeSetSuccessfully()
        {
            var twitterEvent = new TwitterEvent
            {
                Id = "test-id",
                Type = TwitterEventType.MessageCreate,
                Created = DateTime.Today
            };

            Assert.Equal("test-id", twitterEvent.Id);
            Assert.Equal(TwitterEventType.MessageCreate, twitterEvent.Type);
            Assert.Equal(DateTime.Today, twitterEvent.Created);
        }
    }
}
