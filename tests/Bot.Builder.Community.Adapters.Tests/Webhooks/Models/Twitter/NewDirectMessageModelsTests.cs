// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class NewDirectMessageModelsTests
    {
        [Fact]
        public void EventPropertiesShouldBeSetSuccessfully()
        {
            var twitterEvent = new Event
            {
                EventType = "event-type",
                MessageCreate = new NewEvent_MessageCreate()
            };

            var jsonResult = JsonConvert.DeserializeObject<Event>(JsonConvert.SerializeObject(twitterEvent));

            Assert.Equal(twitterEvent.EventType, jsonResult.EventType);
            Assert.Equal(twitterEvent.MessageCreate.GetType(), jsonResult.MessageCreate.GetType());
        }

        [Fact]
        public void NewEvent_QuickReplyPropertiesShouldBeSetSuccessfully()
        {
            var eventQuickReply = new NewEvent_QuickReply
            {
                Options = new List<NewEvent_QuickReplyOption>()
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_QuickReply>(JsonConvert.SerializeObject(eventQuickReply));

            Assert.Equal(eventQuickReply.Options.GetType(), jsonResult.Options.GetType());
        }

        [Fact]
        public void NewEvent_QuickReplyOptionPropertiesShouldBeSetSuccessfully()
        {
            var eventQuickReplyOption = new NewEvent_QuickReplyOption
            {
                Label = "event-label"
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_QuickReplyOption>(JsonConvert.SerializeObject(eventQuickReplyOption));

            Assert.Equal(eventQuickReplyOption.Label, jsonResult.Label);
        }

        [Fact]
        public void NewEvent_MessageCreatePropertiesShouldBeSetSuccessfully()
        {
            var eventMessageCreate = new NewEvent_MessageCreate
            {
                MessageData = new NewEvent_MessageData(),
                target = new Target()
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_MessageCreate>(JsonConvert.SerializeObject(eventMessageCreate));

            Assert.Equal(eventMessageCreate.MessageData.GetType(), jsonResult.MessageData.GetType());
            Assert.Equal(eventMessageCreate.target.GetType(), jsonResult.target.GetType());
        }

        [Fact]
        public void NewEvent_MessageDataPropertiesShouldBeSetSuccessfully()
        {
            var eventMessageData = new NewEvent_MessageData
            {
                QuickReply = new NewEvent_QuickReply(),
                Text = "test-text"
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_MessageData>(JsonConvert.SerializeObject(eventMessageData));

            Assert.Equal(eventMessageData.QuickReply.GetType(), jsonResult.QuickReply.GetType());
            Assert.Equal(eventMessageData.Text, jsonResult.Text);
        }
    }
}
