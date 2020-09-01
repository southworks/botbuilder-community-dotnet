// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class NewDirectMessageModelsTests
    {
        [TestMethod]
        public void EventPropertiesShouldBeSetSuccessfully()
        {
            var twitterEvent = new Event
            {
                EventType = "event-type",
                MessageCreate = new NewEvent_MessageCreate()
            };

            var jsonResult = JsonConvert.DeserializeObject<Event>(JsonConvert.SerializeObject(twitterEvent));

            Assert.AreEqual(twitterEvent.EventType, jsonResult.EventType);
            Assert.AreEqual(twitterEvent.MessageCreate.GetType(), jsonResult.MessageCreate.GetType());
        }

        [TestMethod]
        public void NewEvent_QuickReplyPropertiesShouldBeSetSuccessfully()
        {
            var eventQuickReply = new NewEvent_QuickReply
            {
                Options = new List<NewEvent_QuickReplyOption>()
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_QuickReply>(JsonConvert.SerializeObject(eventQuickReply));

            Assert.AreEqual(eventQuickReply.Options.GetType(), jsonResult.Options.GetType());
        }

        [TestMethod]
        public void NewEvent_QuickReplyOptionPropertiesShouldBeSetSuccessfully()
        {
            var eventQuickReplyOption = new NewEvent_QuickReplyOption
            {
                Label = "event-label"
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_QuickReplyOption>(JsonConvert.SerializeObject(eventQuickReplyOption));

            Assert.AreEqual(eventQuickReplyOption.Label, jsonResult.Label);
        }

        [TestMethod]
        public void NewEvent_MessageCreatePropertiesShouldBeSetSuccessfully()
        {
            var eventMessageCreate = new NewEvent_MessageCreate
            {
                MessageData = new NewEvent_MessageData(),
                target = new Target()
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_MessageCreate>(JsonConvert.SerializeObject(eventMessageCreate));

            Assert.AreEqual(eventMessageCreate.MessageData.GetType(), jsonResult.MessageData.GetType());
            Assert.AreEqual(eventMessageCreate.target.GetType(), jsonResult.target.GetType());
        }

        [TestMethod]
        public void NewEvent_MessageDataPropertiesShouldBeSetSuccessfully()
        {
            var eventMessageData = new NewEvent_MessageData
            {
                QuickReply = new NewEvent_QuickReply(),
                Text = "test-text"
            };

            var jsonResult = JsonConvert.DeserializeObject<NewEvent_MessageData>(JsonConvert.SerializeObject(eventMessageData));

            Assert.AreEqual(eventMessageData.QuickReply.GetType(), jsonResult.QuickReply.GetType());
            Assert.AreEqual(eventMessageData.Text, jsonResult.Text);
        }
    }
}
