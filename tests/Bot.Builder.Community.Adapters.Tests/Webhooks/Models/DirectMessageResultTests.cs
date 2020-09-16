// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models
{
    [Trait("TestCategory", "Twitter")]
    public class DirectMessageResultTests
    {
        [Fact]
        public void DirectMessageResultShouldBeSetSuccessfully()
        {
            var directMessageResult = new DirectMessageResult
            {
                Created = DateTime.Today,
                Id = "test-id",
                RecipientId = "test-recipient",
                SenderId = "test-sender",
                MessageText = "test-message"
            };

            Assert.Equal(DateTime.Today, directMessageResult.Created);
            Assert.Equal("test-id", directMessageResult.Id);
            Assert.Equal("test-recipient", directMessageResult.RecipientId);
            Assert.Equal("test-sender", directMessageResult.SenderId);
            Assert.Equal("test-message", directMessageResult.MessageText);
        }
    }
}
