// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class WebhookDMResultTests
    {
        [Fact]
        public void WebhookDmResultPropertiesShouldBeSetSuccessfully()
        {
            var webhookDmResult = new WebhookDMResult
            {
                Users = new Dictionary<string, TwitterUser>(),
                Events = new List<DMEvent>()
            };

            var jsonResult = JsonConvert.DeserializeObject<WebhookDMResult>(JsonConvert.SerializeObject(webhookDmResult));

            Assert.Equal(webhookDmResult.Users.GetType(), jsonResult.Users.GetType());
            Assert.Equal(webhookDmResult.Events.GetType(), jsonResult.Events.GetType());
        }

        [Fact]
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

            Assert.Equal("event-id", dmEvent.Id);
            Assert.Equal(TwitterEventType.MessageCreate, dmEvent.Type);
            Assert.Equal(1, dmEvent.MessageEntities.media[0].id);
            Assert.Equal("test-text", dmEvent.MessageText);
            Assert.Equal("sender-id", dmEvent.Sender.Id);
            Assert.Equal("recipient-id", dmEvent.Recipient.Id);
        }

        [Fact]
        public void NewDmResultPropertiesShouldBeSetSuccessfully()
        {
            var dmResult = new NewDmResult
            {
                @event = new DMEvent()
            };

            Assert.Equal(typeof(DMEvent), dmResult.@event.GetType());
        }

        [Fact]
        public void MessagePropertiesShouldBeSetSuccessfully()
        {
            var message = new Message
            {
                target = new Target(),
                message_data = new Message_Data(),
                sender_id = "sender-id"
            };

            Assert.Equal("sender-id", message.sender_id);
            Assert.Equal(typeof(Target), message.target.GetType());
            Assert.Equal(typeof(Message_Data), message.message_data.GetType());
        }

        [Fact]
        public void Message_DataPropertiesShouldBeSetSuccessfully()
        {
            var messageData = new Message_Data
            {
                text = "test-text",
                entities = new TwitterEntities(),
                attachment = new Attachment()
            };

            Assert.Equal("test-text", messageData.text);
            Assert.Equal(typeof(TwitterEntities), messageData.entities.GetType());
            Assert.Equal(typeof(Attachment), messageData.attachment.GetType());
        }

        [Fact]
        public void AttachmentPropertiesShouldBeSetSuccessfully()
        {
            var attachment = new Attachment
            {
                type = "attachment-type",
                media = new MediaEntity()
            };

            Assert.Equal("attachment-type", attachment.type);
            Assert.Equal(typeof(MediaEntity), attachment.media.GetType());
        }


        [Fact]
        public void DmEventPropertiesShouldBeSetSuccessfully()
        {
            var dmEvent = new DMEvent
            {
                id = "event-id",
                type = "event-type",
                created_timestamp = 3000,
                message_create = new Message()
            };

            Assert.Equal("event-id", dmEvent.id);
            Assert.Equal("event-type", dmEvent.type);
            Assert.Equal(3000, dmEvent.created_timestamp);
            Assert.Equal(typeof(Message), dmEvent.message_create.GetType());
        }

        [Fact]
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

            Assert.Equal("event-id", dmResult.Id);
            Assert.Equal("test-text", dmResult.MessageText);
            Assert.Equal("sender-id", dmResult.SenderId);
            Assert.Equal("recipient-id", dmResult.RecipientId);
        }
    }
}
