// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alexa.NET.CustomerProfile;
using Alexa.NET.Request;
using Bot.Builder.Community.Adapters.Alexa.Core;
using Bot.Builder.Community.Adapters.Alexa.Tests.Helpers;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Moq;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class AlexaContextExtensionsTests
    {
        private static readonly Mock<BotAdapter> Adapter = new Mock<BotAdapter>();

        [Fact]
        public void GetAlexaRequestBodyWithoutChannelDataShouldReturnNull()
        {
            const string channelData = "channel-data";
            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = channelData
            };

            var result = new TurnContext(Adapter.Object, activity).GetAlexaRequestBody();

            Assert.Null(result);
        }

        [Fact]
        public void GetAlexaRequestBodyWithChannelDataShouldReturnSkillRequest()
        {
            var channelData = SkillRequestHelper.CreateIntentRequest();
            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = channelData
            };

            var result = new TurnContext(Adapter.Object, activity).GetAlexaRequestBody();

            Assert.IsType<SkillRequest>(result);
            Assert.Equal(channelData.Version, result.Version);
        }

        [Fact]
        public void AlexaDeviceHasDisplayShouldReturnTrue()
        {
            var channelData = SkillRequestHelper.CreateIntentRequest();
            var display = new Dictionary<string, object>
            {
                { "Display", "test-display" }
            };

            channelData.Context.System.Device.SupportedInterfaces = display;

            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = channelData
            };

            var result = new TurnContext(Adapter.Object, activity).AlexaDeviceHasDisplay();

            Assert.True(result);
        }

        [Fact]
        public void AlexaDeviceHasDisplayShouldReturnFalse()
        {
            var channelData = SkillRequestHelper.CreateIntentRequest();
            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = channelData
            };

            var result = new TurnContext(Adapter.Object, activity).AlexaDeviceHasDisplay();

            Assert.False(result);
        }

        [Fact]
        public void AlexaDeviceHasAudioPlayerShouldReturnTrue()
        {
            var channelData = SkillRequestHelper.CreateIntentRequest();
            var audioPlayer = new Dictionary<string, object>
            {
                { "AudioPlayer", "test-audio-player" }
            };

            channelData.Context.System.Device.SupportedInterfaces = audioPlayer;

            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = channelData
            };

            var result = new TurnContext(Adapter.Object, activity).AlexaDeviceHasAudioPlayer();

            Assert.True(result);
        }

        [Fact]
        public void AlexaDeviceHasAudioPlayerShouldReturnFalse()
        {
            var channelData = SkillRequestHelper.CreateIntentRequest();
            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = channelData
            };

            var result = new TurnContext(Adapter.Object, activity).AlexaDeviceHasAudioPlayer();

            Assert.False(result);
        }

        [Fact]
        public async Task AlexaSendPermissionConsentRequestActivityShouldSucceed()
        {
            var context = new Mock<ITurnContext>();

            await context.Object.AlexaSendPermissionConsentRequestActivity("message", new List<string>());

            context.Verify(b => b.SendActivityAsync(It.IsAny<IActivity>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void AlexaGetCustomerProfileClientShouldSucceed()
        {
            var request = SkillRequestHelper.CreateIntentRequest();
            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = request
            };
            var context = new Mock<ITurnContext>();
            context.SetupAllProperties();
            context.SetupGet(x => x.Activity).Returns(activity);

            var result = context.Object.AlexaGetCustomerProfileClient();

            Assert.IsType<CustomerProfileClient>(result);
        }

        [Fact]
        public void AlexaSessionAttributesShouldSucceed()
        {
            var request = SkillRequestHelper.CreateIntentRequest();
            request.Session.Attributes = new Dictionary<string, object>
            {
                { "test-attribute", "attribute-value" }
            };

            var activity = new Activity
            {
                Id = "activity-id",
                ChannelData = request
            };

            var context = new Mock<ITurnContext>();
            context.SetupAllProperties();
            context.SetupGet(x => x.Activity).Returns(activity);

            var result = context.Object.AlexaSessionAttributes();

            Assert.Equal(request.Session.Attributes, result);
        }
    }
}
