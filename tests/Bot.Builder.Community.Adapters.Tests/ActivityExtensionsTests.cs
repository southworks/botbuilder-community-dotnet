// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Microsoft.Bot.Schema;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class ActivityExtensionsTests
    {
        [Fact]
        public void AsTwitterMessageWithEmptyMessageShouldFail()
        {
            var activity = new Activity
            {
                Text = null,
                Type = ActivityTypes.Message
            };

            Assert.Throws<TwitterException>(
                () =>
            {
                activity.AsTwitterMessage();
            });
        }

        [Fact]
        public void AsTwitterMessageWithLongMessageShouldFail()
        {
            var activity = new Activity
            {
                Text = new string('a', 10001),
                Type = ActivityTypes.Message
            };

            Assert.Throws<TwitterException>(
                () =>
            {
                activity.AsTwitterMessage();
            });
        }

        [Fact]
        public void AsTwitterMessageShouldReturnNewDirectMessage()
        {
            var activity = new Activity
            {
                Text = "test",
                Type = ActivityTypes.Message,
                Recipient = new ChannelAccount
                {
                    Id = null
                }
            };

            Assert.IsType<NewDirectMessageObject>(activity.AsTwitterMessage());
        }

        [Fact]
        public void AsTwitterMessageShouldReturnNewDirectMessageWithQuickReply()
        {
            var activity = new Activity
            {
                Text = "test",
                Type = ActivityTypes.Message,
                Recipient = new ChannelAccount
                {
                    Id = null
                },
                SuggestedActions = new SuggestedActions
                {
                    Actions = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") }
                }
            };

            Assert.IsType<NewEvent_QuickReply>(activity.AsTwitterMessage().Event.MessageCreate.MessageData.QuickReply);
        }
    }
}
