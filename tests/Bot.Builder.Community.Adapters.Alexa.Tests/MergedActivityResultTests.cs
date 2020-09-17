// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Bot.Builder.Community.Adapters.Alexa.Core;
using Microsoft.Bot.Schema;
using Xunit;

namespace Bot.Builder.Community.Adapters.Alexa.Tests
{
    public class MergedActivityResultTests
    {
        [Fact]
        public void MergedActivityResultShouldBeSetSuccessfully()
        {
            var alexaRequestMapperOptions = new MergedActivityResult
            {
                MergedActivity = new Activity(),
                EndOfConversationFlagged = true
            };

            Assert.IsType<Activity>(alexaRequestMapperOptions.MergedActivity);
            Assert.True(alexaRequestMapperOptions.EndOfConversationFlagged);
        }
    }
}
