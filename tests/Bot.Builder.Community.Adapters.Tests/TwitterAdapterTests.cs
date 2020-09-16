// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Castle.Core.Internal;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests
{
    [Trait("TestCategory", "Twitter")]
    public class TwitterAdapterTests
    {
        private readonly Mock<IOptions<TwitterOptions>> _testOptions = new Mock<IOptions<TwitterOptions>>();

        [Fact]
        public void ConstructorWithOptionsSucceeds()
        {
            Assert.NotNull(new TwitterAdapter(_testOptions.Object));
        }

        [Fact]
        public void UseWithMiddlewareShouldSucceed()
        {
            var adapter = new TwitterAdapter(_testOptions.Object);
            var middleware = new Mock<IMiddleware>();
            var result = adapter.Use(middleware.Object);

            Assert.False(result.MiddlewareSet.IsNullOrEmpty());
        }

        [Fact]
        public async Task ProcessActivityShouldSucceed()
        {
            var adapter = new TwitterAdapter(_testOptions.Object);
            var directMessageEvent = new DirectMessageEvent();
            var bot = new Mock<IBot>();

            directMessageEvent.MessageText = "test message text";
            directMessageEvent.Sender = new TwitterUser();
            directMessageEvent.Recipient = new TwitterUser();
            directMessageEvent.Sender.Id = string.Empty;
            directMessageEvent.Sender.ScreenName = string.Empty;
            directMessageEvent.Recipient.Id = string.Empty;
            directMessageEvent.Recipient.ScreenName = string.Empty;
            bot.SetupAllProperties();

            await adapter.ProcessActivity(directMessageEvent, bot.Object.OnTurnAsync);
            bot.Verify(b => b.OnTurnAsync(It.IsAny<TurnContext>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ProcessActivityShouldReturnNullReferenceException()
        {
            var adapter = new TwitterAdapter(_testOptions.Object);

            await Assert.ThrowsAsync<NullReferenceException>(async () =>
            {
                await adapter.ProcessActivity(null, null);
            });
        }

        [Fact]
        public async Task SendActivitiesAsyncShouldReturnEmptyResponsesWithEmptyActivities()
        {
            var adapter = new TwitterAdapter(_testOptions.Object);
            var activity = new Activity();

            using (var turnContext = new TurnContext(adapter, activity))
            {
                var result = await adapter.SendActivitiesAsync(turnContext, new Activity[0], default);
                Assert.True(result.IsNullOrEmpty());
            }
        }

        [Fact]
        public async Task SendActivitiesAsyncShouldReturnResponseWithActivity()
        {
            var options = new TwitterOptions
            {
                WebhookUri = "uri",
                AccessSecret = "access-secret",
                AccessToken = "access-token",
                ConsumerKey = "consumer-key",
                ConsumerSecret = "consumer-secret",
                Environment = "env",
                Tier = TwitterAccountApi.PremiumFree
            };

            _testOptions.SetupGet(x => x.Value).Returns(options);

            var adapter = new TwitterAdapter(_testOptions.Object);
            var activity = new Activity();

            using (var turnContext = new TurnContext(adapter, activity))
            {
                var activities = new List<Activity>()
                {
                    new Activity()
                    {
                        Id = "3",
                        Type =  ActivityTypes.Message,
                        Text = "Test",
                        Recipient = new ChannelAccount(),
                    }
                };

                var result = await adapter.SendActivitiesAsync(turnContext, activities: activities.ToArray(), default);
                Assert.Single(result);
                Assert.Equal("3", result[0].Id);
            }
        }

        [Fact]
        public async Task UpdateActivityAsyncShouldReturnNotSupportedException()
        {
            var adapter = new TwitterAdapter(_testOptions.Object);
            var activity = new Activity();

            using (var turnContext = new TurnContext(adapter, activity))
            {
                await Assert.ThrowsAsync<NotSupportedException>(async () =>
                {
                    await adapter.UpdateActivityAsync(turnContext, activity, default);
                });
            }
        }

        [Fact]
        public async Task DeleteActivityAsyncShouldReturnNotSupportedException()
        {
            var adapter = new TwitterAdapter(_testOptions.Object);
            var activity = new Activity();
            var conversationReference = new ConversationReference();

            using (var turnContext = new TurnContext(adapter, activity))
            {
                await Assert.ThrowsAsync<NotSupportedException>(async () =>
                {
                    await adapter.DeleteActivityAsync(turnContext, conversationReference, default);
                });
            }
        }
    }
}
