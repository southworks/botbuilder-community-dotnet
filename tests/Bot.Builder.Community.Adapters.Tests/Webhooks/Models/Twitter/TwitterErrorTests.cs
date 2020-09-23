// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Twitter.Webhooks.Models.Twitter;
using Xunit;

namespace Bot.Builder.Community.Adapters.Twitter.Tests.Webhooks.Models.Twitter
{
    [Trait("TestCategory", "Twitter")]
    public class TwitterErrorTests
    {
        [Fact]
        public void TwitterErrorToStringShouldReturnValue()
        {
            var error = new TwitterError
            {
                Errors = new List<Error>
                {
                    new Error { Code = 3, Message = "error-message" }
                }
            };

            Assert.Equal("Error Code: 3, Error Message: error-message", error.ToString());
        }
    }
}
