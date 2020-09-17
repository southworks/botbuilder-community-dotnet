// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Alexa.Core;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class AlexaRequestMapperOptionsTests
    {
        [Fact]
        public void AlexaRequestMapperOptionsShouldBeSetSuccessfully()
        {
            var alexaRequestMapperOptions = new AlexaRequestMapperOptions
            {
                ChannelId = "channel-id",
                ServiceUrl = "service-url",
                DefaultIntentSlotName = "default-intent-slot-name",
                ShouldEndSessionByDefault = false
            };

            Assert.Equal("channel-id", alexaRequestMapperOptions.ChannelId);
            Assert.Equal("service-url", alexaRequestMapperOptions.ServiceUrl);
            Assert.Equal("default-intent-slot-name", alexaRequestMapperOptions.DefaultIntentSlotName);
            Assert.False(alexaRequestMapperOptions.ShouldEndSessionByDefault);
        }
    }
}
