// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class AlexaAdapterOptionsTests
    {
        [Fact]
        public void ConstructorWithDefaultValuesShouldSuccess()
        {
            var alexaOptions = new AlexaAdapterOptions();

            Assert.False(alexaOptions.TryConvertFirstActivityAttachmentToAlexaCard);
            Assert.True(alexaOptions.ValidateIncomingAlexaRequests);
            Assert.True(alexaOptions.ShouldEndSessionByDefault);
        }

        [Fact]
        public void ConstructorWithValuesShouldSuccess()
        {
            var alexaOptions = new AlexaAdapterOptions
            {
                TryConvertFirstActivityAttachmentToAlexaCard = true,
                ValidateIncomingAlexaRequests = false,
                ShouldEndSessionByDefault = false,
                AlexaSkillId = "skill-id"
            };

            Assert.True(alexaOptions.TryConvertFirstActivityAttachmentToAlexaCard);
            Assert.False(alexaOptions.ValidateIncomingAlexaRequests);
            Assert.False(alexaOptions.ShouldEndSessionByDefault);
            Assert.Equal("skill-id", alexaOptions.AlexaSkillId);
        }
    }
}
