// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class TurnContextExTests
    {
        [Fact]
        public async Task OnSendActivitiesShouldSetSentActivitiesSuccessfully()
        {
            var adapter = new Mock<BotAdapter>();
            var activity = new Activity { Id = "activity-id" };
            var context = new TurnContextEx(adapter.Object, activity);
            
            var result = await context.SendActivityAsync(activity);
            
            Assert.Contains(activity, context.SentActivities);
            Assert.NotNull(result);
        }

        [Fact]
        public void SentActivitiesShouldBeSetSuccessfully()
        {
            var adapter = new Mock<BotAdapter>();
            var activity = new Activity { Id = "activity-id" };
            var context = new TurnContextEx(adapter.Object, activity)
            {
                SentActivities = new List<Activity> { activity }
            };

            Assert.Contains(activity, context.SentActivities);
        }
    }
}
