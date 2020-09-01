// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using System.Collections.Generic;
using Newtonsoft.Json;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [TestClass]
    [TestCategory("Twitter")]
    public class WebhookDMResultTests
    {
        [TestMethod]
        public void WebhookDmResultPropertiesShouldBeSetSuccessfully()
        {
            var webhookDmResult = new WebhookDMResult
            {
                Users = new Dictionary<string, TwitterUser>(),
                Events = new List<DMEvent>()
            };

            var jsonResult = JsonConvert.DeserializeObject<WebhookDMResult>(JsonConvert.SerializeObject(webhookDmResult));

            Assert.AreEqual(webhookDmResult.Users.GetType(), jsonResult.Users.GetType());
            Assert.AreEqual(webhookDmResult.Events.GetType(), jsonResult.Events.GetType());
        }

        [TestMethod]
        public void WebhookDmResultShouldConvertToDirectMessageEventSuccessfully()
        {
            DirectMessageEvent dmEvent = new WebhookDMResult
            {
                Users = new Dictionary<string, TwitterUser>
                {
                    ["sender-id"] = new TwitterUser { Id = "sender-id" },
                    ["recipient-id"] = new TwitterUser { Id = "recipient-id" }
                },
                Events = new List<DMEvent> {
                    new DMEvent
                    {
                        id = "event-id",
                        type = "message_create",
                        message_create = new Message
                        {
                            message_data = new Message_Data
                            {
                                text = "test-text",
                                attachment = new Attachment
                                {
                                    media = new MediaEntity
                                    {
                                        id = 1
                                    }
                                },
                                entities = new TwitterEntities()
                            },
                            sender_id = "sender-id",
                            target = new Target { recipient_id = "recipient-id" }
                        }
                    }
                }
            };

            Assert.AreEqual("event-id", dmEvent.Id);
            Assert.AreEqual(TwitterEventType.MessageCreate, dmEvent.Type);
            Assert.AreEqual(1, dmEvent.MessageEntities.media[0].id);
            Assert.AreEqual("test-text", dmEvent.MessageText);
            Assert.AreEqual("sender-id", dmEvent.Sender.Id);
            Assert.AreEqual("recipient-id", dmEvent.Recipient.Id);
        }

        [TestMethod]
        public void NewDmResultPropertiesShouldBeSetSuccessfully()
        {
            var dmResult = new NewDmResult
            {
                @event = new DMEvent()
            };

            Assert.AreEqual(typeof(DMEvent), dmResult.@event.GetType());
        }

        [TestMethod]
        public void MessagePropertiesShouldBeSetSuccessfully()
        {
            var message = new Message
            {
                target = new Target(),
                message_data = new Message_Data(),
                sender_id = "sender-id"
            };

            Assert.AreEqual("sender-id", message.sender_id);
            Assert.AreEqual(typeof(Target), message.target.GetType());
            Assert.AreEqual(typeof(Message_Data), message.message_data.GetType());
        }

        [TestMethod]
        public void Message_DataPropertiesShouldBeSetSuccessfully()
        {
            var messageData = new Message_Data
            {
                text = "test-text",
                entities = new TwitterEntities(),
                attachment = new Attachment()
            };

            Assert.AreEqual("test-text", messageData.text);
            Assert.AreEqual(typeof(TwitterEntities), messageData.entities.GetType());
            Assert.AreEqual(typeof(Attachment), messageData.attachment.GetType());
        }

        [TestMethod]
        public void AttachmentPropertiesShouldBeSetSuccessfully()
        {
            var attachment = new Attachment
            {
                type = "attachment-type",
                media = new MediaEntity()
            };

            Assert.AreEqual("attachment-type", attachment.type);
            Assert.AreEqual(typeof(MediaEntity), attachment.media.GetType());
        }


        [TestMethod]
        public void DmEventPropertiesShouldBeSetSuccessfully()
        {
            var dmEvent = new DMEvent
            {
                id = "event-id",
                type = "event-type",
                created_timestamp = 3000,
                message_create = new Message()
            };

            Assert.AreEqual("event-id", dmEvent.id);
            Assert.AreEqual("event-type", dmEvent.type);
            Assert.AreEqual(3000, dmEvent.created_timestamp);
            Assert.AreEqual(typeof(Message), dmEvent.message_create.GetType());
        }

        [TestMethod]
        public void DmEventInstanceShouldConvertToDirectMessageResultSuccessfully()
        {
            DirectMessageResult dmResult = new DMEvent
            {
                id = "event-id",
                message_create = new Message
                {
                    message_data = new Message_Data
                    {
                        text = "test-text",
                    },
                    sender_id = "sender-id",
                    target = new Target { recipient_id = "recipient-id" }
                }
            };

            Assert.AreEqual("event-id", dmResult.Id);
            Assert.AreEqual("test-text", dmResult.MessageText);
            Assert.AreEqual("sender-id", dmResult.SenderId);
            Assert.AreEqual("recipient-id", dmResult.RecipientId);
        }
    }
}
