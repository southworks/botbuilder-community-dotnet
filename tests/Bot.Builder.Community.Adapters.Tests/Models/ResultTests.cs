// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Newtonsoft.Json;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Models
{
    [Trait("TestCategory", "Twitter")]
    public class ResultTests
    {
        [Fact]
        public void ConstructorSucceeds()
        {
            var result = new Result<bool>();

            Assert.False(result.Success);
        }

        [Fact]
        public void ConstructorWithDataSucceeds()
        {
            var result = new Result<bool>(false);

            Assert.True(result.Success);
            Assert.False(result.Data);
        }

        [Fact]
        public void ConstructorWithTwitterErrorSucceeds()
        {
            var errors = new List<Error>
            {
                JsonConvert.DeserializeObject<Error>("{\r\n  \"Code\": \"401\",\r\n  \"Message\": \"Unauthorized\"\r\n}")
            };

            var twitterError = new TwitterError
            {
                Errors = errors
            };

            var result = new Result<bool>(twitterError);

            Assert.False(result.Success);
            Assert.Equal(twitterError, result.Error);
        }
    }
}
